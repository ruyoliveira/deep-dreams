using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public CardSO[] cardDeck;
    public CardSpawner cardSpawner;
    public CardSO drawnCard;
    public List<CardSO> cardsInHand;
    // Start is called before the first frame update
    void Start()
    {
        
        //foreach(CardSO card in cardsInHand)
        //{
        //    cardSpawner.SpawnCard(card, this.transform);
        //}

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
        drawnCard = cardDeck[Random.Range(0,cardDeck.Length)];
        cardsInHand.Add(drawnCard);
        cardSpawner.SpawnCard(this.drawnCard,this.transform);
    }
}
