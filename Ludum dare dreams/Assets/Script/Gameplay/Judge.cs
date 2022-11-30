using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    private int[] result;


    /// <summary>
    /// Resolve battle based on player and enemy cards
    /// </summary>
    /// <returns>
    /// Array with 4 integers containing result where [0] damage to player, [1] damage to enemy, [2] heal player, [3] heal enemy.
    /// Heal is separated because it happenas after the damage is dealt. 
    /// Negative value loses health and Positive gains
    /// </returns>
    public int[] ResolveBattle(CardSO playerCard, CardSO enemyCard)
    {
        // Init result array
        result = new int[4];
        // Calculate results based in the combination of card types from player and enemy
        // If player played an attack card
        if (playerCard.type == CardType.Attack)
        {
            // Resolve battle conform the enemy card type
            switch (enemyCard.type)
            {
                // Enemy played attack card ,apply damage for both player and enemy
                case CardType.Attack:
                    result[0] = -enemyCard.value;
                    result[1] = -playerCard.value;
                    result[2] = 0;
                    result[3] = 0;
                    break;
                // Enemy played defense card , reduce demage caused by the player
                case CardType.Defense:
                    result[0] = 0;
                    result[1] = Mathf.Clamp(enemyCard.value - playerCard.value, -playerCard.value, 0);
                    result[2] = 0;
                    result[3] = 0;
                    Debug.Log("Def monstro:" + enemyCard.value.ToString());
                    break;
                // Enemy played support card, cause damage to enemy and enemy heals
                case CardType.Support:
                    result[0] = 0;
                    result[1] = -playerCard.value;
                    result[2] = 0;
                    result[3] = enemyCard.value;
                    break;
            }
        }
        // If player played an defense card
        else if (playerCard.type == CardType.Defense)
        {
            // Check enemy card type
            switch (enemyCard.type)
            {
                // If enemy played attack, reduce defense from enemy's card damage
                case CardType.Attack:
                    result[0] = Mathf.Clamp(playerCard.value - enemyCard.value, -enemyCard.value, 0); // Max damage caused is 0.0f
                    result[1] = 0;
                    result[2] = 0;
                    result[3] = 0;
                    break;
                // If played defense, nothing happens
                case CardType.Defense:
                    result[0] = 0;
                    result[1] = 0;
                    result[2] = 0;
                    result[3] = 0;
                    break;
                // If played Support, enemy heals
                case CardType.Support:
                    result[0] = 0;
                    result[1] = 0;
                    result[2] = 0;
                    result[3] = enemyCard.value;
                    break;
            }
        }
        // Player played a support card
        else if (playerCard.type == CardType.Support)
        {
            // Check enemy card type
            switch (enemyCard.type)
            {
                // Enemy's card type attack,player get damage and heals
                case CardType.Attack:
                    result[0] = - enemyCard.value; 
                    result[1] = 0;
                    result[2] = playerCard.value;
                    result[3] = 0;
                    break;
                // Enemy's card type defense, enemy heals
                case CardType.Defense:
                    result[0] = 0;
                    result[1] = 0;
                    result[2] = playerCard.value;
                    result[3] = 0;
                    break;
                // Enemy's card type support, both heal
                case CardType.Support:
                    result[0] = 0;
                    result[1] = 0;
                    result[2] = playerCard.value;
                    result[3] = enemyCard.value;
                    break;
            }
        }

        Debug.Log("Player Card: " + playerCard.cardName);
        Debug.Log("Enemy Card: " + enemyCard.cardName);
        return result;
    }
}
