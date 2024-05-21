using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectSource;

    public AudioClip backgroundMusicClip;
    public AudioClip gameoverMusicClip;
    public AudioClip clickSound;

    private void Awake() //함수 가장빠른 실행 
    {

        if (instance == null) //만약 인스턴스가 비어있다면 
        {
            instance = this; //인스턴스를 이것으로(class오디오매니저) 
            // SceneManager 밑에 넣어서 LoadScene 파괴 방지
        }
        else //그외의 경우 (이미 인스턴스에 있어 재생중일 경우) 
        {
            Destroy(gameObject); //오디오 오브젝트를 파괴함 
        }
    }
    void Start()
    {
        backgroundMusicSource.clip = this.backgroundMusicClip;
        backgroundMusicSource.Play();

        // soundEffectSource 초기화
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
    public void GameOver() 
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

    public void SetSoundValue(float value)
    {
        backgroundMusicSource.volume = value;
        soundEffectSource.volume = value;
           
    }

}

