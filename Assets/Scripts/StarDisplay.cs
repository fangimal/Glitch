using UnityEngine;
using UnityEngine.UI;


[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour
{
    private Text starText;
    private int stars = 100;
    public enum Status { SUCCESS, FAILURE};
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay(); // Обновляем дисплей, что бы изначально было 100 очков, без этого 0
    }

 
    public void AddStars(int amount)//Прибавление очков в ввиде звезд
    {
        stars += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount) //Использование очков
    {
        if (stars >= amount) 
        { 
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;  
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }
}
