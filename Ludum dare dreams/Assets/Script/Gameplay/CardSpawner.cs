using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab;

    /// <summary>
    /// Spawns card on an empty slot in the spawnPosition and populate the card based on the card data
    /// </summary>
    /// <param name="cardSO">card data</param>
    /// <param name="spawnPosition"> player spawnPosition reference</param>
    public GameObject SpawnCard(CardSO cardSO, Transform spawnPosition)
    {
        // Instantiate empty card prefab on the specified spawnPosition
        GameObject instantiatedCard = Instantiate(cardPrefab, spawnPosition);
        // Access cardGUI manager from the instantiated card
        CardGUI cardObj = instantiatedCard.GetComponent<CardGUI>();
        // Setup card using the card data SO
        cardObj.Setup(cardSO);
        // return instantiated card object
        return instantiatedCard;

    }

   
}
