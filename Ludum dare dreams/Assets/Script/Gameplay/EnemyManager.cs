using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Array of scriptable objects containing enemies data
    public EnemySO[] enemiesData;
    // Reference to current enemy
    public Enemy currentEnemy;
    //Current enemy pointer
    public int currentEnemyOrder;
    // Reference to enemy spawner
    public EnemySpawner enemySpawner;

    /// <summary>
    /// Update currentEnemy to next enemy in the array
    /// </summary>
    /// <returns>true if has next enemy, false if there is no more enemies</returns>
    public bool NextEnemy()
    {
        // Desstroy current enemy object
        if(currentEnemy)
            Destroy(currentEnemy.gameObject);
        
        // Check if it is not the last enemy in the array
        if(currentEnemyOrder < enemiesData.Length)
        {
            // Spawn enemy
            enemySpawner.SpawnEnemy(enemiesData[currentEnemyOrder++], enemySpawner.transform);
            // Update current enemy reference
            currentEnemy = enemySpawner.enemyObj;
            // Log new enemy name
            Debug.Log("New enemy: " + enemiesData[currentEnemyOrder].enemyName);
            return true;
        }
        // No more enemies
        else
            return false;
    }
}
