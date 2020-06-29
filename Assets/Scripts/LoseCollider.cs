using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D()
    {
        print("Колайдер пройгрыша");
        //levelManager.Next("Lose");
        SceneManager.LoadScene("Lose");
    }
  
}
