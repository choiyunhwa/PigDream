using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class RetryButton : MonoBehaviour
{
    [SerializeField] private GameObject GameEndPannel;

    public void Retry()
    {
        SoundManager.instance.PlayClickSound();
        GameEndPannel.SetActive(false);
        SystemManager.instance.LoadGamePlayScene();
    }
}