using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    public event Action<Vector2> OnMoveEvent;
    public event Action OnDieEvent;

    public virtual void Awake()
    {
        
    }

    public void CallMoveEvent(Vector2 dir)
    {
        OnMoveEvent?.Invoke(dir);
    }

    private void CallDieEvent()
    {
        OnDieEvent?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(IsLayerMatched(levelCollisionLayer.value, other.gameObject.layer))
        {
            CallDieEvent();
        }
    }

    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }
}
