using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    private float shieldDuration;

    void Start()
    {
        SystemManager.instance.OnGamePlay += StopShield;
    }

    public void ActivateShield()
    {
        if (shieldDuration <= 0) { StartCoroutine("ShieldCoroutine"); }
        else { shieldDuration += 10; }
    }

    public void StopShield()
    {
        StopCoroutine("ShieldCoroutine");
        shieldDuration = 0;
        shield.SetActive(false);
    }

    IEnumerator ShieldCoroutine()
    {
        shieldDuration = 10;
        shield.SetActive(true);
        while (shieldDuration > 0)
        {
            yield return new WaitForSeconds(1f);
            shieldDuration -= 1;
        }
        shield.SetActive(false);
    }
}