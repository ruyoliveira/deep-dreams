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
    /// <param name="cardSO">card data</param>
    /// <param name="hand"> player hand reference</param>
    public GameObject SpawnCard(CardSO cardSO, Transform hand)
    {
        GameObject instantiatedCard = Instantiate(cardPrefab, hand);
        CardGUI cardObj = instantiatedCard.GetComponent<CardGUI>();
        cardObj.Setup(cardSO);
        return instantiatedCard;


    }

   
}