using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource; 
   
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log($"Не уничтожено при загрузке {name}");
    }

    private void Start()
    {
        audioSource = GetComponent <AudioSource>();
    }
    private void OnLevelWasLoaded(int level)
    {
        AudioClip thislevelMusic = levelMusicChangeArray[level];
        Debug.Log($"Играет: {thislevelMusic}");

        if (thislevelMusic) //если файл прикреплян к массиву
        {
            audioSource.clip = thislevelMusic; //прикрепляем музыку к источнику
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
