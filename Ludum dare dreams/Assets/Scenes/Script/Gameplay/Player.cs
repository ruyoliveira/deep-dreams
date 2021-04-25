using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerHand hand;
    public Judge battleJudge;
    public void Start()
    {
        Debug.Log(battleJudge.ResolveBattle(hand.cardsInHand[0], hand.cardsInHand[1]));
    }
}
