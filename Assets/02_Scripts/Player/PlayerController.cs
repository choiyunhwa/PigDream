using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action CharacterSettingEvent;
    public event Action<Vector2> OnMoveEvent;
    public event Action OnDieEvent;

    public virtual void Awake()
    {
        SystemManager.instance.OnGamePlay += CallSettingEvet;
           
    }

    public void CallMoveEvent(Vector2 dir)
    {
        OnMoveEvent?.Invoke(dir);
    }

    private void CallDieEvent()
    {
        OnDieEvent?.Invoke();
    }

    private void CallSettingEvet()
    {
        CharacterSettingEvent?.Invoke();
    }
}
