using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyGUI : MonoBehaviour
{
    /// <summary>
    /// Array of sprites of the card mold organized in order Attack, Defense and Support
    /// </summary>
    public CardSO[] enemyCards;
    public Image graphic;
    public Text description;
    public Text enemyName;
    public Text healthPoints;


    public void Setup(EnemySO enemyData)
    {

        graphic.sprite = enemyData.graphic;
        description.text = enemyData.description;
        enemyName.text = enemyData.name;
        healthPoints.text = enemyData.healthPoints.ToString();
        //rarity.text = cardData.rarity.ToString();

       

    }
}
