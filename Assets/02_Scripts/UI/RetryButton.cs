using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        SoundManager.instance.PlayClickSound();
        SystemManager.instance.LoadGamePlayScene();
    }
}