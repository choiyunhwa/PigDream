using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject GameEndPannel;

    public void GotoGameStart()
    {
        SoundManager.instance.PlayClickSound();
        SoundManager.instance.PlayClickSound();
        if (SoundManager.instance.gameoverMusicClip != null)
        {
            SoundManager.instance.backgroundMusicSource.clip = SoundManager.instance.backgroundMusicClip;
            SoundManager.instance.backgroundMusicSource.Play();
        }
        SystemManager.instance.LoadGameStartScene();
        GameEndPannel.SetActive(false);
    }
}
