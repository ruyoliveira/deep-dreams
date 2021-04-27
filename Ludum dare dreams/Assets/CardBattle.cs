using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBattle : MonoBehaviour
{
    public CardGUI cardBattleGUI1;
    public CardGUI cardBattleGUI2;
    public CardSO cardBattleSO1;
    public CardSO cardBattleSO2;
    public bool endBattle;
    public float timer;
    public float maxTime;

    public void ClearCards()
    {
        cardBattleGUI1.gameObject.SetActive(false);
        cardBattleGUI2.gameObject.SetActive(false);

    }
    public void PositionCards(CardSO card1, CardSO card2)
    {
        cardBattleSO1 = card1;
        cardBattleSO2 = card2;
        cardBattleGUI1.Setup(cardBattleSO1);
        cardBattleGUI1.Setup(cardBattleSO2);
        endBattle = false;

    }
    public void EndBattle()
    {
        ClearCards();
        endBattle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!endBattle)
        {
            timer += Time.deltaTime;
            if (timer > maxTime)
            {
                EndBattle();
            }
        }
       
    }
}
