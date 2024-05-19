using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject PausePannel;

    public void PausePannelOn()
    {
        SoundManager.instance.PlayClickSound();
        Time.timeScale = 0.0f;
        PausePannel.SetActive(true);
    }
}
