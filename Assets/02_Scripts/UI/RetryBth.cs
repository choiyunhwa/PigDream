using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class RetryButton : MonoBehaviour
{
    public GameObject HtpPanel;
    public GameObject EndPanel;
    [SerializeField] private PlayerSO player; //�����ؾ���

    public void End()
    {
        EndPanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("GamePlayScene");
        
    }
}