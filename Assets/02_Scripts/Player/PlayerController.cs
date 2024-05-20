using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<PlayerSO> CharacterSettingEvent;
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

    public void CallSettingEvet(PlayerSO player)
    {
        CharacterSettingEvent?.Invoke(player);
    }
}
