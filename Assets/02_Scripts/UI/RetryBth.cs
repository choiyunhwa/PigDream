using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class RetryButton : MonoBehaviour
{
    public GameObject HtpPanel;
    public GameObject EndPanel;
    [SerializeField] private PlayerSO player; //변경해야함

    public void End()
    {
        EndPanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("GamePlayScene");
        
    }
}