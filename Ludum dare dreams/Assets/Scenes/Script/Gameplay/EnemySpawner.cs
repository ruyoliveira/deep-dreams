using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Enemy enemyObj;
    public GameObject spawnedEnemyGameObject;
    /// <summary>
    /// Load enemy from ScriptableObject, intantiate enemy on the spawn point and setup on GUI
    /// </summary>
    /// <param name="enemyData">enemy data</param>
    /// <param name="enemySpot"> enemy spawn spot reference</param>
    public void SpawnEnemy(EnemySO enemyData, Transform enemySpot)
    {
        
        spawnedEnemyGameObject = Instantiate(enemyPrefab, enemySpot); // instantiate prefab
        enemyObj = spawnedEnemyGameObject.GetComponent<Enemy>(); // acess enemy runtime object
        enemyObj.LoadEnemy(enemyData); // load enemy data to runtime sobject
        EnemyGUI enemyGUI = spawnedEnemyGameObject.GetComponent<EnemyGUI>();
        enemyGUI.Setup(enemyData);


    }
}
