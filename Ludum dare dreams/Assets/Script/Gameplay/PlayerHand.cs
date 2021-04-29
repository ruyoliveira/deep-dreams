using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public Deck gameDeck;
    public CardSO[] cardDeck;
    public CardSpawner cardSpawner;
    public CardSO drawnCard;
    public CardSO selectedCard;
    public CardGUI selectedCardGUI;
    public int selectedCardId;
    public List<GameObject> cardsInHandObj;
    public bool canPickCard = false;
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
    public void DrawCard(int turn, bool[] cardDraft)
    {
        //if(gameDeck!= null)
        //    gameDeck.DivideCardsInCategory();
        drawnCard = gameDeck.DrawRandomCard(cardDraft[0], cardDraft[1], cardDraft[2], cardDraft[3], cardDraft[4]);//cardDeck[Random.Range(0,cardDeck.Length)];
        GameObject spawnedCard = cardSpawner.SpawnCard(this.drawnCard, this.transform);
        spawnedCard.GetComponent<CardClickNotifier>().SetCardID(cardsInHandObj.Count, this); // setup click notifier of instantiated card
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
    public void PickCard(CardGUI cardGUI)
    {
        if(canPickCard)
        {

       
        Debug.Log("Player SelectedCard:" + cardGUI.cardData.cardName);
        selectedCard = cardGUI.cardData;//cardsInHandObj[id].GetComponent<CardGUI>().cardData;
        selectedCardGUI = cardGUI;
            //selectedCardId = cardsInHandObj.Find(cardGUI.gameObject);
        }


    }
    public void Discard2(GameObject obj)
    {
        cardsInHandObj.Remove(obj);
        Destroy(obj);
    }
    public void DiscardUsedCard(int id)
    {

        //GameObject obj = cardsInHandObj[id];
        //cardsInHandObj.RemoveAt(id);
        //Destroy(obj);

    }
    public CardSO UseCurrentCard()
    {
        CardSO usedCard = this.selectedCard;
        Discard2(selectedCardGUI.gameObject);
        //DiscardUsedCard(this.selectedCardId);
        this.selectedCard = null;
        return usedCard;
    }
}
