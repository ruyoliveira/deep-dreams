using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    /// <summary>
    /// enemy name
    /// </summary>
    public string enemyName;
    /// <summary>
    /// Cards data
    /// </summary>
    public CardSO[] cards;
    /// <summary>
    /// 2D sprite to be used in the card
    /// </summary>
    public Sprite graphic;
    /// <summary>
    /// Resumed card description
    /// </summary>
    public string description;
    /// <summary>
    /// Identifies if normal or boss enemy
    /// </summary>
    public EnemyType enemyType;
    /// <summary>
    /// Total ealth points 
    /// </summary>
    public int healthPoints;

    /// <summary>
    /// Current health points 
    /// </summary>
    public int currentHealthPoints;
    /// <summary>
    /// Reference for enemy GUI
    /// </summary>
    public EnemyGUI enemyGUI;

    /// <summary>
    /// Enemy data
    /// </summary>
    public EnemySO enemySO;

    public void LoadEnemy(EnemySO enemyData)
    {
        this.enemySO = enemyData;
        this.enemyName = enemyData.enemyName;
        this.cards = enemyData.cards;
        this.graphic = enemyData.graphic;
        this.description = enemyData.description;
        this.enemyType = enemyData.enemyType;
        this.healthPoints = enemyData.healthPoints;
        this.currentHealthPoints = enemyData.healthPoints;

    }

   
}
