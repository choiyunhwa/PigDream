using UnityEngine;

public class ShieldCollider : MonoBehaviour
{
    [SerializeField] private LayerMask AvoidFoodCollisionLayer;
    [SerializeField] private PlayerShield shieldScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsLayerMatched(AvoidFoodCollisionLayer.value, other.gameObject.layer))
        {
            shieldScript.StopShield();
        }
    }
    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }
}
