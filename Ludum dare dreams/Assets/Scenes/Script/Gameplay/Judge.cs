using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    private Vector4 result;
    /// <summary>
    /// 
    /// </summary>
    /// <returns>
    /// Vector2 containing result where x: player received damage, y: enemy received damage, z: player heal, w: enemy heal.
    /// Heal is separated because it happenas after the damage is dealt. 
    /// Negative value loses health and Positive gains
    /// </returns>
    public Vector4 ResolveBattle(CardSO playerCard, CardSO enemyCard)
    {

        if (playerCard.type == CardType.Attack)
        {
            switch (enemyCard.type)
            {
                case CardType.Attack:
                    result.x = -enemyCard.value;
                    result.y = -playerCard.value;
                    result.z = 0.0f;
                    result.w = 0.0f;
                    break;
                case CardType.Defense:
                    result.x = 0.0f;
                    result.y = Mathf.Clamp(enemyCard.value - playerCard.value, playerCard.value, 0.0f);
                    result.z = 0.0f;
                    result.w = 0.0f;
                    break;
                case CardType.Support:
                    result.x = 0.0f;
                    result.y = -playerCard.value;
                    result.z = 0.0f;
                    result.w = enemyCard.value;
                    break;
            }
        }
        else if (playerCard.type == CardType.Defense)
        {
            switch (enemyCard.type)
            {
                case CardType.Attack:
                    result.x = Mathf.Clamp(playerCard.value - enemyCard.value, enemyCard.value, 0.0f); // Max damage caused is 0.0f
                    result.y = -playerCard.value;
                    result.z = 0.0f;
                    result.w = 0.0f;
                    break;
                case CardType.Defense:
                    result.x = 0.0f;
                    result.y = 0.0f;
                    result.z = 0.0f;
                    result.w = 0.0f;
                    break;

                case CardType.Support:
                    result.x = 0.0f;
                    result.y = 0.0f;
                    result.z = 0.0f;
                    result.w = enemyCard.value;
                    break;
            }
        }
        // Both used support cards, cause no damage and heal
        else
        {
            result.x = 0.0f;
            result.y = 0.0f;
            result.z = playerCard.value;
            result.w = enemyCard.value;
        }
       

        return result;
    }
}
