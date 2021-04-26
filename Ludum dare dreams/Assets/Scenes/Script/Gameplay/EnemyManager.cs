using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemySO[] enemiesData;
    public Enemy currentEnemy;
    public EnemySpawner enemySpawner;
    public void Start()
    {
        enemySpawner.SpawnEnemy(enemiesData[0], enemySpawner.transform);

    }
    public void Update()
    {
        
    }
    
    public void NextEnemy()
    {

    }
}
