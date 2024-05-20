using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private LayerMask playerCollisionLayer;

    private int scorePoint = 100;   // 임시 점수 설정

    private void Start()
    {
        float x = Random.Range(-2.45f, 2.45f);
        transform.position = new Vector2(x, 5.2f);
    }
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 2; // 속도 스케일링
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsLayerMatched(playerCollisionLayer.value, other.gameObject.layer))
        { GameManager.instance.ScoreEarn(scorePoint); }
        gameObject.SetActive(false);
    }
    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }
}
