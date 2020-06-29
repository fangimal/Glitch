using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] attackerPrefabArray; //167-9-55 Создаём массив, в котором будт содержаться элементы спауна.

    void Update()
    {
        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }
    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform; //Атакера привязываем к Spawner
        myAttacker.transform.position = transform.position; //Появление на определённой позиции
    }
    bool isTimeToSpawn (GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>(); // Получаем доступ к аттакеру
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnPerSeconds = 1 / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Количество ограничено из-за фрейм рейта");
        }
        float threshold = spawnPerSeconds * Time.deltaTime/5; //Потолок по значению
        
        return (Random.value < threshold); //Возвращает true или false
      
    }
}
