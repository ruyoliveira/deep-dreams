using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<CardSO> normalDeck;
    public List<CardSO> refinedDeck;
    public List<CardSO> uniqueDeck;
    public List<CardSO> superDeck;
    public List<CardSO> eliteDeck;

    public List<CardSO> allCards;

    public bool isDivided = false;
 
    public void DivideCardsInCategory()
    {
        normalDeck = new List<CardSO>();
        refinedDeck = new List<CardSO>();
        uniqueDeck = new List<CardSO>();
        superDeck = new List<CardSO>();
        eliteDeck = new List<CardSO>();

        foreach(CardSO card in allCards)
        {
            switch(card.rarity)
            {
                case  CardRarity.Normal:
                    normalDeck.Add(card);
                    break;
                   
                case CardRarity.Refined:
                    refinedDeck.Add(card);
                    break;
                case CardRarity.Unique:
                    uniqueDeck.Add(card);
                    break;
                case CardRarity.Super:
                    superDeck.Add(card);
                    break;
                case CardRarity.Elite:
                    eliteDeck.Add(card);
                    break;
            }
            isDivided = true;
        }
    }

    public CardSO DrawRandomCard(bool normal, bool refined, bool unique, bool super, bool elite)
    {
        if(!isDivided)
        {
            DivideCardsInCategory();
        }
        List<CardSO> combinedCardList = new List<CardSO>();
        if (normal)
            combinedCardList.AddRange(this.normalDeck);
        if(refined)
            combinedCardList.AddRange(this.refinedDeck);
        if (unique)
            combinedCardList.AddRange(this.uniqueDeck);
        if (super)
            combinedCardList.AddRange(this.superDeck);
        if (elite)
            combinedCardList.AddRange(this.eliteDeck);

        return combinedCardList[Random.Range(0,combinedCardList.Count)];

    }

}
