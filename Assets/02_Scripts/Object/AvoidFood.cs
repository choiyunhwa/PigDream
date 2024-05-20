using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidFood : MonoBehaviour
{
    [SerializeField] private LayerMask playerCollisionLayer;

    private void Start()
    {
        float x = Random.Range(-2.45f, 2.45f);
        transform.position = new Vector2(x, 5.2f);
    }
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 2 * SpawnManager.instance.speedScaling; // 속도 스케일링
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsLayerMatched(playerCollisionLayer.value, other.gameObject.layer))
        { SystemManager.instance.CallGameOver(); }
        gameObject.SetActive(false);
    }
    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }
}
