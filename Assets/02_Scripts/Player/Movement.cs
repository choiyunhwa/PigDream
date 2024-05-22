using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D rigid;

    private Vector3 movementDirection = Vector3.zero;
    private float speed;

    private int speedUPDuration = 0;
    private float speedUP = 1.0f;

    private Coroutine walkSoundCoroutine;
    private bool isMoving;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        rigid = GetComponent<Rigidbody2D>();

        controller.CharacterSettingEvent += GetPlayerSpeed;
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);

        if (movementDirection != Vector3.zero && !isMoving)
        {
            isMoving = true;
            walkSoundCoroutine = StartCoroutine(PlayWalkSound());
        }
        else if (movementDirection == Vector3.zero && isMoving)
        {
            isMoving = false;
            if (walkSoundCoroutine != null)
            {
                StopCoroutine(walkSoundCoroutine);
                walkSoundCoroutine = null;
            }
        }
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void GetPlayerSpeed(PlayerSO player)
    {
        speed = player.speed;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * speed * speedUP;
        rigid.velocity = direction;
    }

    public void StartSpeedUP()
    {
        if (speedUPDuration <= 0)
        {
            StartCoroutine(SpeedUP());
        }
        else
        {
            speedUPDuration += 10;
        }
    }

    IEnumerator SpeedUP()
    {
        speedUPDuration += 10;
        speedUP = 2f;
        while (speedUPDuration > 0)
        {
            yield return new WaitForSeconds(1f);
            speedUPDuration -= 1;
        }
        speedUP = 1f;
    }

    private IEnumerator PlayWalkSound()
    {
        while (true)
        {
            SoundManager.instance.PlayWalkSound();

            float interval = Mathf.Max(0.41f, 1f / (speed * speedUP));
            yield return new WaitForSeconds(interval);
        }
    }
}
