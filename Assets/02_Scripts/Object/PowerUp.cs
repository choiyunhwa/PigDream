using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject PowerUPSPEED;

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 2.5f * SpawnManager.instance.speedScaling; // 속도 스케일링
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlayItemSound();
            PowerUPSPEED.SetActive(true);
            Movement playerCoroutine = collision.gameObject.GetComponent<Movement>();
            playerCoroutine.StartSpeedUP();
        }
        gameObject.SetActive(false);
    }
}