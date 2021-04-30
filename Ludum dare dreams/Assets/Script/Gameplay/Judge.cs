using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    private int[] result;
    /// <summary>
    /// 
    /// </summary>
    /// <returns>
    /// Vector2 containing result where x: player received damage, y: enemy received damage, z: player heal, w: enemy heal.
    /// Heal is separated because it happenas after the damage is dealt. 
    /// Negative value loses health and Positive gains
    /// </returns>
    public int[] ResolveBattle(CardSO playerCard, CardSO enemyCard)
    {
        result = new int[4];
        if (playerCard.type == CardType.Attack)
        {
            switch (enemyCard.type)
            {
                case CardType.Attack:
                    result[0] = -enemyCard.value;
                    result[1] = -playerCard.value;
                    result[2] = 0;
                    result[3] = 0;
                    break;
                case CardType.Defense:
                    result[0] = 0;
                    result[1] = Mathf.Clamp(enemyCard.value - playerCard.value, -playerCard.value, 0);
                    result[2] = 0;
                    result[3] = 0;
                    Debug.Log("Def monstro:" + enemyCard.value.ToString());
                    break;
                case CardType.Support:
                    result[0] = 0;
                    result[1] = -playerCard.value;
                    result[2] = 0;
                    result[3] = enemyCard.value;
                    break;
            }
        }
        else if (playerCard.type == CardType.Defense)
        {
            switch (enemyCard.type)
            {
                case CardType.Attack:
                    result[0] = Mathf.Clamp(playerCard.value - enemyCard.value, -enemyCard.value, 0); // Max damage caused is 0.0f
                    result[1] = 0;
                    result[2] = 0;
                    result[3] = 0;
                    break;
                case CardType.Defense:
                    result[0] = 0;
                    result[1] = 0;
                    result[2] = 0;
                    result[3] = 0;
                    break;

                case CardType.Support:
                    result[0] = 0;
                    result[1] = 0;
                    result[2] = 0;
                    result[3] = enemyCard.value;
                    break;
            }
        }
        // Both used support cards, cause no damage and heal
        else if (playerCard.type == CardType.Support)
        {
            switch (enemyCard.type)
            {
                case CardType.Attack:
                    result[0] = - enemyCard.value; // Max damage caused is 0.0f
                    result[1] = 0;
                    result[2] = playerCard.value;
                    result[3] = 0;
                    break;
                case CardType.Defense:
                    result[0] = 0;
                    result[1] = 0;
                    result[2] = playerCard.value;
                    result[3] = 0;
                    break;

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
