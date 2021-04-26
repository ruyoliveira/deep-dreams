using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePhases {BEGIN_TURN, PLANNING, RESOLVE_BATTLE, END_TURN}
/// <summary>
/// Manages the game actions and transition between phases
/// </summary>
public class GamePhasesManager : MonoBehaviour
{
    public GamePhases currentPhase;
    public Player player;
    public EnemyManager enemyManager;
    public Judge battleJudge;

    public CardSO playerSelectedCard;
    public CardSO enemySelectedCard;


    
    void Start()
    {
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentPhase)
        {
            case GamePhases.BEGIN_TURN:
                //Debug.Log("BEGIN_TURN");
                BeginTurnPhase();
                break;
            case GamePhases.PLANNING:
                //Debug.Log("PLANNING");
                PlanningPhase();
                break;
            case GamePhases.RESOLVE_BATTLE:
                //Debug.Log("RESOLVE_BATTLE");
                ResolveBattlePhase();
                break;
            case GamePhases.END_TURN:
                //Debug.Log("END_TURN");
                EndTurnPhase();
                break;
            
        }
    }
    /// <summary>
    /// Addvances for the next phases. Loop back to begin turn after end turn
    /// </summary>
    public void NextPhase()
    {
         currentPhase = currentPhase != GamePhases.END_TURN? currentPhase+1: GamePhases.BEGIN_TURN;
    }
    /// <summary>
    /// Game setup
    /// </summary>
    public void GameSetup()
    {
        // Player draws three cards
        player.hand.DrawCard();
        player.hand.DrawCard();
        enemyManager.NextEnemy();
    }

    /// <summary>
    /// Actions in the begin turn phase. Draws card and transition to PlanningPhase;
    /// </summary>
    public void BeginTurnPhase()
    {
        Debug.Log("Begin turn - Player HP: " + player.hp);
        Debug.Log("Begin turn - Enemy HP: " + enemyManager.currentEnemy.currentHealthPoints);
        player.hand.DrawCard();
        NextPhase();

            
    }
    /// <summary>
    /// Player and enemy select desired card to use in resolve battle phase. Wait players select card using game HUD. Enemy picks its card conform its attack order.
    /// </summary>
    public void PlanningPhase()
    {
        if(player.hand.selectedCard!= null)
        {
            enemySelectedCard = enemyManager.currentEnemy.UseCurrentCard();
            playerSelectedCard = player.hand.UseCurrentCard();
            NextPhase();
        }
    }
    /// <summary>
    /// Resulve battle comparing both card choices. Updates player and enemy hp based on the results.
    /// </summary>
    public void ResolveBattlePhase()
    {

        // todo: move cards to battle area
        int[] battleResult = battleJudge.ResolveBattle(playerSelectedCard,enemySelectedCard);
      
        Debug.Log(battleResult[0].ToString() + battleResult[1].ToString() + battleResult[2].ToString() + battleResult[3].ToString());
        ProcessBattleResult(battleResult); 
        NextPhase();

    }
    /// <summary>
    /// Clears card choices and advance for begin turn phase
    /// </summary>
    public void EndTurnPhase()
    {
        // todo: discard cards
        playerSelectedCard = null;
        enemySelectedCard = null;
        NextPhase();
    }

    /// <summary>
    /// Aapplies damage and recovery for enemy and player and notificates both managers in case of defeat
    /// </summary>
    /// <param name="battleResult"></param>
    public void ProcessBattleResult(int[] battleResult)
    {
        player.AddDamage(battleResult[0]);  // applies damage to player
        enemyManager.currentEnemy.AddHP( battleResult[1]);   // apples damage to player
        if(player.hp <=0)
        {
            // todo game over
            Debug.Log("GameOver");
        }
        else if(enemyManager.currentEnemy.currentHealthPoints <= 0)
        {
            Debug.Log("Monster defeated");
            enemyManager.NextEnemy();   // call next enemy
            NextPhase();    // continue to next game phase
        }
        else 
        {
            
            player.hp += battleResult[2]; // Recover HP after  damage is applied and if both survived
            enemyManager.currentEnemy.AddHP(battleResult[3]);
        }
        Debug.Log("After Battle - Player HP: " + player.hp);
        Debug.Log("After Battle - Enemy HP: " + enemyManager.currentEnemy.currentHealthPoints);





    }

}
