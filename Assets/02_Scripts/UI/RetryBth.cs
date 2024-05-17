using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class RetryButton : MonoBehaviour
{
    public GameObject HtpPanel;
    public GameObject EndPanel;

    public void Bth()
    {
        SoundManager soundManager = FindAnyObjectByType<SoundManager>();

        if (soundManager != null)
        {
            soundManager.PlayClickSound();
        }
    }

    public void Htp()
    {
        Bth();
        HtpPanel.SetActive(true);
    }

    public void Retry()
    {
        Bth();
        SceneManager.LoadScene("GamePlayScene");
    }
}