using UnityEngine;


public class Defender : MonoBehaviour
{
    public int starCost = 100; //Стоимость по умолчанию

    private StarDisplay stardisplay; //


    public void AddStars(int amount)
    {
        stardisplay.AddStars(amount);
    }

    void Start()
    {
        stardisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

}
