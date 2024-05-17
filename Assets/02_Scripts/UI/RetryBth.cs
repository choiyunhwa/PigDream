using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class RetryButton : MonoBehaviour
{
    public GameObject HtpPanel;
    public GameObject EndPanel;

    public void End()
    {
        EndPanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("GamePlayScene");

    }
}