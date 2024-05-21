using UnityEngine;

public class PowerUPBig : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 2.5f * SpawnManager.instance.speedScaling; // 속도 스케일링
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ObjectPoolManager.instance.PowerUPSizeChange(1);
        }
        gameObject.SetActive(false);
    }
}
