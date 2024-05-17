using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource backgroundMusicSource;
    public AudioSource gameoverMusicSource;
    public AudioSource soundEffectSource;

    public AudioClip backgroundMusicClip;
    public AudioClip gameoverMusicClip;
    public AudioClip clickSound;

    private void Awake() //함수 가장빠른 실행 
    {

        if (instance == null) //만약 인스턴스가 비어있다면 
        {
            instance = this; //인스턴스를 이것으로(class오디오매니저) 
            DontDestroyOnLoad(gameObject); //씬이 넘어가도 오브젝트 파괴를 못함 
        }
        else //그외의 경우 (이미 인스턴스에 있어 재생중일 경우) 
        {
            Destroy(gameObject); //오디오 오브젝트를 파괴함 
        }
    }
    void Start()
    {
        backgroundMusicSource = GetComponent<AudioSource>();
        backgroundMusicSource.clip = this.backgroundMusicClip;
        backgroundMusicSource.Play();

        // soundEffectSource 초기화
        soundEffectSource = gameObject.AddComponent<AudioSource>();
    }
    // 클릭 효과음 재생 메서드 
    public void PlayClickSound() // 함수 “PlayClickSound” 
    {
        if (clickSound != null)
        {
            soundEffectSource.clip = clickSound;
            soundEffectSource.Play();
        }
    }
    public void GameOver() // 함수 “PlayClickSound” 
    {
        if (gameoverMusicClip != null)
        {
            soundEffectSource.clip = gameoverMusicClip;
            StopMusicPlay();
            soundEffectSource.Play();
        }
    }
    public void StopMusicPlay()
    {
        if (backgroundMusicClip != null)
        {
            backgroundMusicSource.Stop();
        }
    }

}

