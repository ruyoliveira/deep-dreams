using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemySO[] enemiesData;
    public Enemy currentEnemy;
    public int currentEnemyOrder;
    public EnemySpawner enemySpawner;
    public void Start()
    {
        //enemySpawner.SpawnEnemy(enemiesData[0], enemySpawner.transform);
        //currentEnemyOrder = 0;
        //NextEnemy();

    }
    public void Update()
    {
        
    }
    
    public void NextEnemy()
    {
        if(currentEnemy)
            Destroy(currentEnemy.gameObject);
        enemySpawner.SpawnEnemy(enemiesData[currentEnemyOrder++], enemySpawner.transform);
        currentEnemy = enemySpawner.enemyObj;
        Debug.Log("New enemy: "+ enemiesData[currentEnemyOrder].enemyName);
    }
}
