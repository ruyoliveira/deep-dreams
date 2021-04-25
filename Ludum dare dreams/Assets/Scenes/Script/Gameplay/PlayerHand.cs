using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
   
    public CardSpawner cardSpawner;
    public CardSO drawnCard;
    public CardSO[] cardsInHand;
    // Start is called before the first frame update
    void Start()
    {
        foreach(CardSO card in cardsInHand)
        {
            cardSpawner.SpawnCard(card, this.transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Draws a new card, spawn and update the HUD to put it in the players hand
    /// </summary>
    public void DrawCard()
    {
        cardSpawner.SpawnCard(this.drawnCard,this.transform);
    }
}
