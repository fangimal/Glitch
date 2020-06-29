using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera; //Получаем доступ к камер
    private GameObject Parent;
    private StarDisplay starDisplay;

    private void Start()
    {
        //Размещаем создаваемые дефендеры в объекте дефендерс
        Parent = GameObject.Find("Defenders"); // Находим игровой объект с таким названием
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        if (!Parent)//если такого нет, то
        {
            Parent = new GameObject("Defenders"); //Создаём новый игровой объект
        }
        
    }
    void OnMouseDown()
    {
        //print(Input.mousePosition); //Возврощает координаты мыши
        //print(SnapToGrid(CalculateWorldPointOfMouseClick()));
        Vector2 rawPos = CalculateWorldPointOfMouseClick(); //Получаем координаты клика мыши
        Vector2 roudedPos = SnapToGrid(rawPos); // Округляем координаты
        GameObject defender = Button.selectedDefender;
        
        int defenderCost = defender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roudedPos, defender);
        }
        else
        {
            Debug.Log("Недостаточно звёзд");
        }
        
    }

    private void SpawnDefender(Vector2 roudedPos, GameObject defender)
    {
        Quaternion zeroRot = Quaternion.identity;
        GameObject newDef = Instantiate(defender, roudedPos, zeroRot) as GameObject;
        newDef.transform.parent = Parent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos) //Метод для округления координат, что бы получить ыентр квадрат на игровой сетке
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x); //Округляем значение
        float newY= Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY); //возврощаем округлённое значение
    }
    Vector2 CalculateWorldPointOfMouseClick() //Переводим координаты клика мыши из пикслелей в мировую систему
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
