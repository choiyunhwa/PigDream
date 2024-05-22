using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private LayerMask playerCollisionLayer;
    [SerializeField] private LayerMask shieldCollisionLayer;

    private int scorePoint = 100;   // �ӽ� ���� ����

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 2 * SpawnManager.instance.speedScaling; // �ӵ� �����ϸ�
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(IsLayerMatched(shieldCollisionLayer, other.gameObject.layer)) { return; }

        if (IsLayerMatched(playerCollisionLayer.value, other.gameObject.layer))
        { 
            GameManager.instance.ScoreEarn(scorePoint);
            SoundManager.instance.PlayClickSound();
        }
        gameObject.SetActive(false);
    }
    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }
}
