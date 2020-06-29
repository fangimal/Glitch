using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private Slider slider;
    public float levelSeconds; //Время в секундах
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;
    Scene scene;
    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        levelManager = GameObject.FindObjectOfType<LevelManager>();// Пишем так, а не как выше потомучто скрипт мы ищем в другом объекте, в этом его нету, в инспекторе посмотри.
        FindYouWin();
        winLabel.SetActive(false);

    }

    private void FindYouWin() //При выйгрыше выводит текст выйгрыша
    {
        winLabel = GameObject.Find("You win");
        if (!winLabel)
        {
            Debug.LogWarning("Создайте Текст выйгрыша!");
        }
    }

    void Update()
    {

        slider.value = Time.timeSinceLevelLoad / levelSeconds; // Time.timeSinceLevelLoad время прошедщее от загрузки уровня
       if (slider.value >= 1)
        {
            bool timeIsUp = Time.timeSinceLevelLoad >= levelSeconds; //Время закончелось
            if (timeIsUp && !isEndOfLevel) //Если время закончилось и сейчас уровень ещё активен т.е. не false, то 
            {
                audioSource.Play();
                winLabel.SetActive(true);
                print("Уровень пройден!");
                Invoke("LoadNextLevel", audioSource.clip.length); //Перед загрузкой следующего уровня нужно подождать, время равное времени проигрывания аудио
                isEndOfLevel = true;
            }
        }
       
    }
    void LoadNextLevel()
    {
        //SceneManager.LoadScene("Level_02");
        print("Загрузка сцены " + scene.buildIndex);
        levelManager.LoadNextLevel();
    }

}
