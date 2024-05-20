using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject GameEndPannel;

    public void GotoGameStart()
    {
        SoundManager.instance.PlayClickSound();
        SystemManager.instance.LoadGameStartScene();
        GameEndPannel.SetActive(false);
    }
}
