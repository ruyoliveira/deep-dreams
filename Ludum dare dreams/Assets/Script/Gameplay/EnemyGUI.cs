using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles enemy GUI
/// </summary>
public class EnemyGUI : MonoBehaviour
{
    // Enemy image
    public Image graphic;
    // Animator
    public Animator animator;
    // Descrioption  Text UI
    public Text description;
    // Name Text UI
    public Text enemyName;
    // HP Text UI
    public Text healthPoints;

    /// <summary>
    /// Populate enemy UI using enemy data
    /// </summary>
    /// <param name="enemyData">Enemy data</param>
    public void Setup(EnemySO enemyData)
    {
        // Populate GUI elements using enemy data
        graphic.sprite = enemyData.graphic;
        description.text = enemyData.description;
        enemyName.text = enemyData.name;
        healthPoints.text = enemyData.healthPoints.ToString();
        animator.runtimeAnimatorController = enemyData.animatorController;

    }
   
}
