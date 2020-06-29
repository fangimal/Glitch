using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour
{
    public float fadeInTime; //Время появления изображения
    private Image fadePanel;
    private Color curentColor = Color.black;


    void Start()
    {
        fadePanel = GetComponent<Image>(); //Заходим в свойство компонента Panel в Image
        
    }

 
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime) //Хотим сделать плавное появление
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            curentColor.a -= alphaChange; //curentColor.a  - изменяем альфа канал
            fadePanel.color = curentColor; //цвет нашей панали равен curentColor
        }
        // После мы должны диактевировать панель, в противном случае он будет загораживать другие окна
        else
        {
            gameObject.SetActive(false); //То же самое что убираем галочку с элемента в инспекторе
        }
    }
}
