using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider, difficultSlider;
    public LevelManager levelManager;

    private MusicManager musicManager;
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        //Debug.LogError(musicManager);

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultSlider.value = PlayerPrefsManager.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        musicManager.SetVolume(volumeSlider.value);
        
    }

    public void SaveAndExit() //перед тем как выйти из настроек сохраняем изменённые значения
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultSlider.value);

        levelManager.Next("Start");
    }

    public void SetDefault()
    {
        volumeSlider.value = 0.8f;
        difficultSlider.value = 2f;
    }
}
