using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class RetryButton : MonoBehaviour
{
    [SerializeField] private GameObject GameEndPannel;

    public void Retry()
    {
        SoundManager.instance.PlayClickSound();
        if (SoundManager.instance.gameoverMusicClip != null)
        {
            SoundManager.instance.backgroundMusicSource.clip = SoundManager.instance.backgroundMusicClip;
            SoundManager.instance.backgroundMusicSource.Play();
        }
        GameEndPannel.SetActive(false);
        SystemManager.instance.LoadGamePlayScene();
    }
}