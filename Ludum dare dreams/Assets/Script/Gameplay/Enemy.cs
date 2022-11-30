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
    /// Animator controller to be used on enemy animator
    /// </summary>
    public RuntimeAnimatorController animatorController;
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
    /// Current card following enemy deck
    /// </summary>
    public int currentCardId;
    /// <summary>
    /// Current card data
    /// </summary>
    public CardSO currentCardData;
    /// <summary>
    /// Reference for enemy GUI
    /// </summary>
    public EnemyGUI enemyGUI;
    /// <summary>
    /// Enemy data
    /// </summary>
    public EnemySO enemySO;

    /// <summary>
    /// Populate enemy info using card data SO
    /// </summary>
    /// <param name="enemyData"></param>
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
        this.animatorController = enemyData.animatorController;
        this.currentCardId = 0;
        this.currentCardData = cards[this.currentCardId];
    }
    /// <summary>
    /// Move to next card
    /// </summary>
    public void NextCard()
    {
        // Update current card ID
        this.currentCardId = this.currentCardId < cards.Length-1 ? ++currentCardId: 0;
        // Get current card data from array
        this.currentCardData = cards[this.currentCardId];
    }
    /// <summary>
    /// Use current card
    /// </summary>
    /// <returns>used card data(SO)</returns>
    public CardSO UseCurrentCard()
    {
        // Get used card data
        CardSO usedCard = this.currentCardData;
        // Move to next card
        NextCard();
        return usedCard;
    }

    /// <summary>
    /// Referesh GUI to reflect current enemy state
    /// </summary>
    public void RefreshGUI()
    {
        enemyGUI.healthPoints.text = currentHealthPoints.ToString();
    }
    /// <summary>
    /// Add/subtracts health points
    /// </summary>
    /// <param name="value">amount to be added</param>
    public void AddHP(int value)
    {
        // Add value to health points
        currentHealthPoints += value;
        // Referesh GUI to reflect current enemy state
        RefreshGUI();
    }

}
