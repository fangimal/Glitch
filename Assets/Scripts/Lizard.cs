using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))] //Необходим компонент атакер, защитное поле, если у объекта нет скрипта атакер, юните его добавит
public class Lizard : MonoBehaviour
{
    private Animator anim;
    private Attacker attacker;
    void Start()
    {
        anim = GetComponent<Animator>(); //находим компоненты
        attacker = GetComponent<Attacker>();
    }


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (!obj.GetComponent<Defender>()) // если у компонента нет скрипта дефендер
        {
            return; // выходим со скрипта, скрипт не срабатывает
        }
        
        anim.SetBool("IsAttacking", true);
        attacker.Attack(obj); //цель атаки из скрипта аттак
    }
}
