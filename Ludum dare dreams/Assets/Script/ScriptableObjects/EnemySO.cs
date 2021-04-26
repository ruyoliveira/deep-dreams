using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {Normal, Boss };
/// <summary>
/// Object container for enemy related information
/// </summary>
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 2)]
public class EnemySO : ScriptableObject
{
    public string enemyName;
    public CardSO[] cards;
    /// <summary>
    /// 2D sprite to be used in the card
    /// </summary>
    public Sprite graphic;
    /// <summary>
    /// Resumed card description
    /// </summary>
    public string description;
    /// <summary>
    /// Identifies if normal or boss enemy
    /// </summary>
    public EnemyType enemyType;
    /// <summary>
    /// Health points 
    /// </summary>
    public int healthPoints;
    /// <summary>
    /// Animator containing all animations and transitions
    /// </summary>
    public RuntimeAnimatorController animatorController;

}
