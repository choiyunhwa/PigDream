using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void Start()
    {
        float x = Random.Range(-2.45f, 2.45f);
        transform.position = new Vector2(x, 5.2f);
    }
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 2.5f * SpawnManager.instance.speedScaling; // 속도 스케일링
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlayItemSound();
            Movement playerCoroutine = collision.gameObject.GetComponent<Movement>();
            playerCoroutine.StartSpeedUP();
        }
        gameObject.SetActive(false);
    }
}
