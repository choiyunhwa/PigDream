using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject PausePannel;

    public void GotoGameStart()
    {
        SoundManager.instance.PlayClickSound();
        SystemManager.instance.LoadGameStartScene();
        PausePannel.SetActive(false);
    }
}
