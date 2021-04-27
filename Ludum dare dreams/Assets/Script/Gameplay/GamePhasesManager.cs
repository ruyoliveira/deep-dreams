using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int turnCounter;
    public int energyPerTurn= 2;
    /// <summary>
    /// Each slot corresponds to a card rarity. Specifies if a specific rarity is locked(false) or unlocker(true) for draw phase
    /// </summary>
    public bool[] cardDraft;
    
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
        turnCounter = 0;
        player.AddEnergy(3);
        cardDraft = new bool[5] { true, false, false, false, false}; // Starts only with normal cards
        player.hand.DrawCard(turnCounter, cardDraft);
        player.hand.DrawCard(turnCounter,cardDraft);
        enemyManager.currentEnemyOrder = 0;
        enemyManager.NextEnemy();
       
    }

    /// <summary>
    /// Actions in the begin turn phase. Draws card and transition to PlanningPhase;
    /// </summary>
    public void BeginTurnPhase()
    {
        Debug.Log("Begin turn - Player HP: " + player.hp);
        Debug.Log("Begin turn - Enemy HP: " + enemyManager.currentEnemy.currentHealthPoints);
        player.hand.DrawCard(turnCounter, cardDraft);
        NextPhase();

            
    }
    /// <summary>
    /// Player and enemy select desired card to use in resolve battle phase. Wait players select card using game HUD. Enemy picks its card conform its attack order.
    /// </summary>
    public void PlanningPhase()
    {
        if(player.hand.selectedCard!= null)
        {
            // Verifies if has eneough energy and uses
            if(player.hand.selectedCard.cost <= player.energy)
            {
                // TODO Consume card energy
                //player.AddEnergy(- player.hand.selectedCard.cost);
                enemySelectedCard = enemyManager.currentEnemy.UseCurrentCard();
                playerSelectedCard = player.hand.UseCurrentCard();
                NextPhase();
            }
            // Pick another card
            else
            {
                Debug.Log("Not enough energy");
                player.hand.selectedCard = null;
            }
           
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
        turnCounter++;
        // Rises enrgy per turn until 10
        player.AddEnergy(energyPerTurn + Mathf.Clamp(turnCounter, 1, 9));
        // Max energy 10
        if(player.energy > 10)
        {
            player.AddEnergy(-(player.energy - 10));
        }
        if(turnCounter < cardDraft.Length)
            cardDraft[turnCounter] = true;
        NextPhase();
    }




    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
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
            GameOver();
        }
        else
        {
            player.AddDamage( battleResult[2] ); // Recover HP after  damage is applied and if both survived

        }
        if (enemyManager.currentEnemy.currentHealthPoints <= 0)
        {
            Debug.Log("Monster defeated");
            enemyManager.NextEnemy();   // call next enemy
            NextPhase();    // continue to next game phase
        }
        else 
        {
            
            enemyManager.currentEnemy.AddHP(battleResult[3]);
        }
        Debug.Log("After Battle - Player HP: " + player.hp);
        Debug.Log("After Battle - Enemy HP: " + enemyManager.currentEnemy.currentHealthPoints);

    }


}
