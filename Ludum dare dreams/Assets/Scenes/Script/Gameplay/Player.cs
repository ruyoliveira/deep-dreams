using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerHand hand;
    public int energy;
    public int hp;
    public int maxHP;
    public PlayerGUI playerGUI;
    public void Start()
    {
        RefreshGUI();
    }
    public void RefreshGUI()
    {
        playerGUI.hp.text = this.hp.ToString();

    }
    public void AddDamage(int value)
    {
        hp += value;
        RefreshGUI();
    }
}
