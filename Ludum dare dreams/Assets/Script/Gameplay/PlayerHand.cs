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
    public int selectedCardId;
    public List<GameObject> cardsInHandObj;
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
    public void DrawCard(int turn)
    {
        //if(gameDeck!= null)
        //    gameDeck.DivideCardsInCategory();
        drawnCard = gameDeck.DrawRandomCard(true,false, false, false, false);//cardDeck[Random.Range(0,cardDeck.Length)];
        GameObject spawnedCard = cardSpawner.SpawnCard(this.drawnCard, this.transform);
        spawnedCard.GetComponent<CardClickNotifier>().SetCardID(cardsInHandObj.Count, this); // setup click notifier of instantiated card
        cardsInHandObj.Add(spawnedCard);
        
    }

    public void PickCard(CardGUI cardGUI)
    {
        Debug.Log("Player SelectedCard:" + cardGUI.cardData.cardName);
        selectedCard = cardGUI.cardData;//cardsInHandObj[id].GetComponent<CardGUI>().cardData;
        Discard2(cardGUI.gameObject);
        //selectedCardId = cardsInHandObj.Find(cardGUI.gameObject);

 
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
        //DiscardUsedCard(this.selectedCardId);
        this.selectedCard = null;
        return usedCard;
    }
}
