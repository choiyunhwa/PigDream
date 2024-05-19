using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowButton : MonoBehaviour
{
    [SerializeField] private GameObject HowPannel;

    public void HowPannelOn()
    {
        SoundManager.instance.PlayClickSound();
        HowPannel.SetActive(true);
    }
}
