using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public CardSpawner cardSpawner;
    public CardSO drawnCard;
    // Start is called before the first frame update
    void Start()
    {
        BeginTurn();
        BeginTurn();
        BeginTurn();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginTurn()
    {
        cardSpawner.SpawnCard(this.drawnCard,this.transform);
    }
}
