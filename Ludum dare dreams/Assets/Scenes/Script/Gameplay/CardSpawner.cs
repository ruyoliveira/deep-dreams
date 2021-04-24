using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardSpawner : MonoBehaviour
{
   

    public GameObject cardPrefab;

    /// <summary>
    /// Spawns card on an empty slot in the hand
    /// </summary>
    /// <param name="card">card data</param>
    /// <param name="hand"> player hand reference</param>
    public void SpawnCard(CardSO card, Transform hand)
    {
        GameObject instantiatedCard = Instantiate(cardPrefab, hand);
        Card cardObj = instantiatedCard.GetComponent<Card>();
        cardObj.Setup(card);


    }

   
}
