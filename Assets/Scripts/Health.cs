using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public void DealDamage (float damage) //нанесение урона
    {
        health -= damage;
        if (health < 0)
        {
            //Если есть, то запустить анимацию смерти
            DestroyObject();
        }
    }

    public void DestroyObject() // Если есть анимация смерти объектов, в анимации нужно добавить эвент\событие и вызвать этот метод
    {
        Destroy(gameObject);
    }
}
