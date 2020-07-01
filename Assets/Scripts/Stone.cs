using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>(); // Находим Аниматор, GetComponent поскольку на одном же уровне что и скрипт (видно в инспекторе если ыделить префаб
    }

    private void Update()
    {
        
    }
    // Переключаем состояние анимации камня 
    private void OnTriggerStay2D(Collider2D collider) //Stay учитывается всё то время пока идёт пересечение
    {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            animator.SetTrigger("underAttack trigger");
        }
    }
}
