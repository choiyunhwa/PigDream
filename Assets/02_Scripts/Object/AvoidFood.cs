using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class AvoidFood : MonoBehaviour
{
    public IObjectPool<GameObject> pool { get; set; }

    [SerializeField] private LayerMask playerCollisionLayer;

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
