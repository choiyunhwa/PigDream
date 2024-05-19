using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyButton : MonoBehaviour
{
    [SerializeField] private GameObject ReadyPannel;

    public void ReadyPannelOn()
    {
        SoundManager.instance.PlayClickSound();
        ReadyPannel.SetActive(true);
    }
}
