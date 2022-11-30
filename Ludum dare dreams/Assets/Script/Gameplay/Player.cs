using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Reference to hand object
    public PlayerHand hand;
    // Current energy
    public int energy;
    // Health points
    public int hp;
    // Max health points
    public int maxHP;
    // Reference to player GUI
    public PlayerGUI playerGUI;
    
    public void Start()
    {
        // Refresh GUI
        RefreshGUI();
    }
    /// <summary>
    /// Update GUI elements with the current player status
    /// </summary>
    public void RefreshGUI()
    {
        playerGUI.hp.text = this.hp.ToString();
        playerGUI.energy.text = this.energy.ToString();

    }

    /// <summary>
    /// Add damage to player
    /// </summary>
    /// <param name="value">amount of damage</param>
    public void AddDamage(int value)
    {
        // Apply value to hp
        hp += value;
        // Refresh information shown on GUI
        RefreshGUI();
    }
    /// <summary>
    /// Add enegergy
    /// </summary>
    /// <param name="value"> amout of energy</param>
    public void AddEnergy(int value)
    {
        // Apply value to energy
        energy += value;
        // Refresh information shown on GUI
        RefreshGUI();

    }
    /// <summary>
    /// Set energy
    /// </summary>
    /// <param name="value">energy value</param>
    public void SetEnergy(int value)
    {
        // Set energy value
        energy = value;
        // Referesh GUI
        RefreshGUI();

    }
}
