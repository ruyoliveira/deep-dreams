using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Enum related to card types
/// </summary>
public enum CardType {Attack, Support, Special};

/// <summary>
/// Object container for card related information
/// </summary>
[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card", order = 1)]
public class CardSO : ScriptableObject
{
    /// <summary>
    /// Card name, avoid numbers
    /// </summary>
    public string cardName;
    /// <summary>
    /// Card type. Can be Attack, Support, Special
    /// </summary>
    public CardType type;
    /// <summary>
    /// 2D sprite to be used in the card
    /// </summary>
    public Sprite graphic;
    /// <summary>
    /// Summon cost
    /// </summary>
    public int cost;
    /// <summary>
    /// General value, if attack type this relates to the damage the card does. 
    /// </summary>
    public int value;
    /// <summary>
    /// Resumed card description
    /// </summary>
    public string description;


    
}
