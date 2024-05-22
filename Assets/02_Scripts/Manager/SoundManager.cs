using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectSource;
    public AudioSource walksoundEffectSource;

    public AudioClip backgroundMusicClip;
    public AudioClip gameoverMusicClip;
    public AudioClip clickSound;
    public AudioClip eatSound;
    public AudioClip hitSound;
    public AudioClip itemSound;
    public AudioClip stepSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 오브젝트가 파괴되지 않도록 합니다.
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (gameoverMusicClip != null)
        {
            backgroundMusicSource.clip = backgroundMusicClip;
            backgroundMusicSource.Play();
        }
    }
    
    public void Music()
    {
        StopMusicPlay();
        backgroundMusicSource.clip = backgroundMusicClip;
        backgroundMusicSource.Play();
    }

    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            soundEffectSource.clip = clickSound;
            soundEffectSource.Play();
        }
    }

    public void PlayEatSound()
    {
        if (clickSound != null)
        {
            soundEffectSource.clip = eatSound;
            soundEffectSource.Play();
        }
    }

    public void PlayHitSound()
    {
        if (clickSound != null)
        {
            soundEffectSource.clip = hitSound;
            soundEffectSource.Play();
        }
    }

    public void PlayItemSound()
    {
        if (clickSound != null)
        {
            soundEffectSource.clip = itemSound;
            soundEffectSource.Play();
        }
    }


    public void PlayWalkSound()
    {
        if (stepSound != null)
        {
            walksoundEffectSource.clip = stepSound;
            walksoundEffectSource.Play();
        }
    }

    public void GameOver()
    {
        if (gameoverMusicClip != null)
        {
            StopMusicPlay();
            backgroundMusicSource.clip = gameoverMusicClip;
            backgroundMusicSource.Play();
        }
    }

    public void StopMusicPlay()
    {
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.Stop();
        }
    }
}
