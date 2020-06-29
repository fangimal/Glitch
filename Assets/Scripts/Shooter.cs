using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile, gun; //Этими предметами будут стрелять наши объекты
    
    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>(); // находим аниматор типа аниматор
        // Projectiles снаряды будут упорядочены в этом элементе в иерархии при проигрывании
        //при необходимости создает родителя
        projectileParent = GameObject.Find("Projectiles"); // Находим игровой объект с таким названием
        if (!projectileParent)//если такого нет, то
        {
            projectileParent = new GameObject("Projectiles"); //Создаём новый игровой объект
            
        }

        SetMyLaneSpawner();
        //print(myLaneSpawner);
    }

    void SetMyLaneSpawner() // Просматривает все Spawner на наличие дочерних объектов
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>(); //Найдём объекты Spawner и добавим к массиву
        foreach(Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y) // Если координата у у spawner и координата текущего объекта совпадают, то
            {
                myLaneSpawner = spawner;
                return;
            }
            Debug.LogError(name +" Не могу найти спаунер на линии");
        }
    }
    bool IsAttackerAheadLane()
    {
        //Выходит если аттакеров нет на линии
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        // Если аттакеры будут найдены то
        foreach(Transform attackers in myLaneSpawner.transform) //В каждом дочернем объекте myLaneSpawner
        {
            if (attackers.transform.position.x > transform.position.x) 
            { 
                return true; 
            }
        }
        //если объекты позади возвращаем фалсе
        return false;
    }
    private void Update()
    {
        //Сделаем так что бы дефендеры переходили в состояние атаки только тогда когда на линии появляется противник
        if (IsAttackerAheadLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
