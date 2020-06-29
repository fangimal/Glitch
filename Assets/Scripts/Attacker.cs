using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour

{
    //[Range(-1f, 1.5f)] //Создаём ползунок значении для переменной walkSpeed в инспекторе
    private float currentSpeed;
    [Tooltip ("Среднее количество секунд между появляниями врагов.")] // Всплывающая подсказка в инспекторе на переменную ниже
    public float seenEverySeconds;

    private GameObject currentTarget;
    private Health health;
    private Animator animator;

    private GameObject Parent;
    void Start()
    {
        Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>(); //добавление риджитбоду через скрипт
        myRigidbody.isKinematic = true; // присваиваем тип кинематик.
        animator = GetComponent<Animator>();
        Parent = GameObject.Find("Spawner");
    }

   
    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (currentTarget)
        {
            animator.SetBool("IsAttacking", true);
        }
        else animator.SetBool("IsAttacking", false);
    }

    void OnTriggerEnter2D()
    {
        //Debug.Log(name + " Произошло столкновение.");
    }

    public void SetSpeed (float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }   
    }

    public void Attack (GameObject obj)
    {
        currentTarget = obj;
    }

    void Spawn (GameObject myGameObject)
    {

    }
}
