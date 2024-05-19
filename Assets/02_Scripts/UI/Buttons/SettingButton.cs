using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    [SerializeField] private GameObject SettingPannel;

    public void SettingPannelOn()
    {
        SoundManager.instance.PlayClickSound();
        SettingPannel.SetActive(true);
    }
}
