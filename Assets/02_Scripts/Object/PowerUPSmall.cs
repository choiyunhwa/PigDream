using UnityEngine;

public class PowerUPSmall : MonoBehaviour
{
    [SerializeField] private LayerMask playerCollisionLayer;
    [SerializeField] private LayerMask shieldCollisionLayer;
    private FoodAnimator animator;
    private void Awake()
    {
        animator = GetComponent<FoodAnimator>();
    }
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 2.5f * SpawnManager.instance.speedScaling; // 속도 스케일링
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsLayerMatched(shieldCollisionLayer, other.gameObject.layer)) { return; }

        if (IsLayerMatched(playerCollisionLayer.value, other.gameObject.layer))
        {
            SoundManager.instance.PlayItemSound();
            animator.IsHit(true);
            ObjectPoolManager.instance.PowerUPSizeChange(0);
        }
        Invoke("Disabled", 3f);
    }

    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }

    private void Disabled()
    {
        gameObject.SetActive(false);
        animator.IsHit(false);
    }
}
