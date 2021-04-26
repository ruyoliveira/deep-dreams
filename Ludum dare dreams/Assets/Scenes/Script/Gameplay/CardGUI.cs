using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardGUI : MonoBehaviour
{
    /// <summary>
    /// Array of sprites of the card mold organized in order Attack, Defense and Support
    /// </summary>
    public Sprite[] cardColoredMold;
    public Image cardMold;
    public Image graphic;
    public Text description;
    public Text cardName;
    public Text value;
    public Text cost;
    public Text rarity;

    public CardSO cardSO;

    public void Setup(CardSO cardData)
    {
        this.cardSO = cardData;
        graphic.sprite = cardData.graphic;
        description.text = cardData.description;
        cardName.text = cardData.name;
        value.text = cardData.value.ToString();
        cost.text = cardData.cost.ToString();
        //rarity.text = cardData.rarity.ToString();

        switch (cardData.type)
        {
            case CardType.Attack:
                cardMold.sprite = cardColoredMold[0];
                break;
            case CardType.Defense:
                cardMold.sprite = cardColoredMold[1];
                break;
            case CardType.Support:
                cardMold.sprite = cardColoredMold[2];
                break;

        }

    }
}
