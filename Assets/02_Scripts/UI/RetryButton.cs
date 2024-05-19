using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class RetryButton : MonoBehaviour
{
    [SerializeField] private GameObject PausePannel;

    public void Retry()
    {
        SoundManager.instance.PlayClickSound();
        PausePannel.SetActive(false);
        SystemManager.instance.LoadGamePlayScene();
    }
}