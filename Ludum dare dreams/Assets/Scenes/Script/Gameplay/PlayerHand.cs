using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public CardSO[] cardDeck;
    public CardSpawner cardSpawner;
    public CardSO drawnCard;
    public CardSO selectedCard;
    public List<CardSO> cardsInHand;
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
    public void DrawCard()
    {
        drawnCard = cardDeck[Random.Range(0,cardDeck.Length)];
        cardsInHand.Add(drawnCard);
        GameObject spawnedCard = cardSpawner.SpawnCard(this.drawnCard, this.transform);
        spawnedCard.GetComponent<CardClickNotifier>().SetCardID(cardsInHandObj.Count, this); // setup click notifier of instantiated card
        cardsInHandObj.Add(spawnedCard);
        
    }

    public void PickCard(int id)
    {
        Debug.Log("PickedCard");
        selectedCard = cardsInHand[id];
        DiscardUsedCard(id);
    }
    public void DiscardUsedCard(int id)
    {
        cardsInHand.RemoveAt(id);
        
        GameObject obj = cardsInHandObj[id];
        cardsInHandObj.RemoveAt(id);
        Destroy(obj);

    }
}
