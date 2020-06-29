using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float autoLoadNextLevelAfter;
    
    void Start()
    {
        if (autoLoadNextLevelAfter <= 0)
            Debug.Log("Уровень Автолог выключен, используёте положительное число!");
        else Invoke("LoadNextLevel", autoLoadNextLevelAfter);
    }

    public void Next(string name)
    {
        Debug.Log("Запрошена загрузка уровня для: " + name);
        //Application.LoadLevel(name);
        SceneManager.LoadScene(name);
    }
    public void QuitRequest()
    {
        Debug.Log("Я хочу выйти!");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        int number = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(number + 1);
        
    }

}
