using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private GameObject CurrentPannel;

    public void CurrentPannelClose()
    {
        SoundManager.instance.PlayClickSound();
        CurrentPannel.SetActive(false);
    }
}
