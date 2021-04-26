using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClickNotifier : MonoBehaviour
{
    /// <summary>
    /// Reference for playerhand, gets on start
    /// </summary>
    public PlayerHand parentPlayerHand;
    /// <summary>
    /// Card ID generated at spawn
    /// </summary>
    public int cardId;
    // Start is called before the first frame update
    void Start()
    {
        parentPlayerHand = transform.parent.GetComponent<PlayerHand>();
    }
    /// <summary>
    /// Sets cardID and playerHand at creation
    /// </summary>
    /// <param name="cardID">card id reference</param>
    /// <param name="playerHand">parent playerhand reference</param>
    public void SetCardID(int cardID, PlayerHand playerHand)
    {
        this.cardId = cardID;
        this.parentPlayerHand = playerHand;
    }
    /// <summary>
    /// Notifies player hand that card has been clicked
    /// </summary>
    /// <param name="cardId"></param>
    public void NotifyClickPlayerHand()
    {
        parentPlayerHand.PickCard(this.cardId);
    }
}
