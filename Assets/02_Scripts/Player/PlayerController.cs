using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;

    public virtual void Awake()
    {
        
    }

    public void CallMoveEvent(Vector2 dir)
    {
        OnMoveEvent?.Invoke(dir);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //面倒 贸府 内靛 眠啊
    }
}
