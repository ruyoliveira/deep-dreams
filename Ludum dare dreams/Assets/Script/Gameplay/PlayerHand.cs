using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    // Reference to player's card deck manager
    public Deck gameDeck;
    // Data of cards into deck
    public CardSO[] cardDeck;
    // Card spawner reference
    public CardSpawner cardSpawner;
    // Drawn card data
    public CardSO drawnCard;
    // Selected card data
    public CardSO selectedCard;
    // Card GUI handler  reference
    public CardGUI selectedCardGUI;
    // List of cards in hand
    public List<GameObject> cardsInHandObj;
    // Can pick card flag
    public bool canPickCard = false;


    /// <summary>
    /// Draws a new card, spawn and update the HUD to put it in the players hand
    /// </summary>
    /// <param name="turn">current turn</param>
    /// <param name="cardDraft">enabled rarities array</param>
    public void DrawCard(int turn, bool[] cardDraft)
    {
        // Draw card from the enabled card rarities specified on the cardDraft array
        drawnCard = gameDeck.DrawRandomCard(cardDraft[0], cardDraft[1], cardDraft[2], cardDraft[3], cardDraft[4]);//cardDeck[Random.Range(0,cardDeck.Length)];
        // Spawn card and store reference to new card game object
        GameObject spawnedCard = cardSpawner.SpawnCard(this.drawnCard, this.transform);
        // Setup click notifier of instantiated card
        spawnedCard.GetComponent<CardClickNotifier>().SetCardID(cardsInHandObj.Count, this); 
        // Add instantiated card to list of cards in hand
        cardsInHandObj.Add(spawnedCard);

    }
    // Enable/disable card picking during the right phase
    public void EnableCardPicking()
    {
        canPickCard = true;
    }
    public void DisableCardPicking()
    {
        canPickCard = false;
    }
    /// <summary>
    /// Pick/select card from hand to use
    /// </summary>
    /// <param name="cardGUI">cardGUI handler reference</param>
    public void PickCard(CardGUI cardGUI)
    {
        // Check if can pick card
        if (canPickCard)
        {
            Debug.Log("Player SelectedCard:" + cardGUI.cardData.cardName);
            // Get card data from cardGUI
            selectedCard = cardGUI.cardData;
            // Store cardGUI of selected card
            selectedCardGUI = cardGUI;
        }


    }
    /// <summary>
    /// Discard used card
    /// </summary>
    /// <param name="obj">reference to card object</param>
    public void Discard(GameObject obj)
    {
        // Remove card from list
        cardsInHandObj.Remove(obj);
        // Destroy card object
        Destroy(obj);
    }

    /// <summary>
    /// Use current card procedure
    /// </summary>
    /// <returns>reference to used card data (SO)</returns>
    public CardSO UseCurrentCard()
    {
        // Get data from used card
        CardSO usedCard = this.selectedCard;
        // Discard
        Discard(selectedCardGUI.gameObject);
        // Empty selectedCard variable
        this.selectedCard = null;
        // Returns used card data
        return usedCard;
    }
}
