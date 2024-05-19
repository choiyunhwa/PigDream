using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void Retry()
    {
        SoundManager.instance.PlayClickSound();
        SystemManager.instance.LoadGameStartScene();
    }
}
