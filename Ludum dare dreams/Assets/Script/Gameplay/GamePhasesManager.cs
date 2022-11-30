using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GamePhases {BEGIN_TURN, PLANNING, BATTLE_PHASE, RESOLVE_BATTLE, END_TURN}
/// <summary>
/// Manages the game actions and transition between phases
/// </summary>
public class GamePhasesManager : MonoBehaviour
{
    // Current phase
    public GamePhases currentPhase;
    // Reference to player
    public Player player;
    // Reference to EnemyManager
    public EnemyManager enemyManager;
    // Reference to Judge
    public Judge battleJudge;
    // Reference to battle GUI
    public CardBattle battleGUI;
    // Player selected card data - ScriptableObject
    public CardSO playerSelectedCard;
    // Enemy selected card data  - ScriptableObject
    public CardSO enemySelectedCard;
    // Battle turn counter
    public int turnCounter;
    // Amount of energy that is recovered per turn
    public int energyPerTurn= 2;
    // Boss background, activated only when boss appears
    public GameObject bossBackground;

    /// <summary>
    /// Each slot corresponds to a card rarity. Specifies if a specific rarity is locked(false) or unlocker(true) for draw phase
    /// </summary>
    public bool[] cardDraft;
    
    void Start()
    {
        // Setup game scene
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {
        // Execute the method  to the current phase 
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
            case GamePhases.BATTLE_PHASE:
                BattlePhase();
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
    /// Game setup: player draws three cards
    /// </summary>
    public void GameSetup()
    {
        // Reset turn counter to 0
        turnCounter = 0;
        // Add 3 energies to player
        player.AddEnergy(3);
        // Add only normal cards to the draft deck
        cardDraft = new bool[5] { true, false, false, false, false}; // Starts only with normal cards
        // Draw two cards
        player.hand.DrawCard(turnCounter, cardDraft);
        player.hand.DrawCard(turnCounter,cardDraft);
        // Reset enemy encounter order
        enemyManager.currentEnemyOrder = 0;
        // Start encounter with next enemy 
        enemyManager.NextEnemy();
       
    }

    /// <summary>
    /// Actions in the begin turn phase. Draws card and transition to PlanningPhase;
    /// </summary>
    public void BeginTurnPhase()
    {
        Debug.Log("Begin turn - Player HP: " + player.hp);
        Debug.Log("Begin turn - Enemy HP: " + enemyManager.currentEnemy.currentHealthPoints);
        // Draws one card
        player.hand.DrawCard(turnCounter, cardDraft);
        // Enable interacting with the cards
        player.hand.EnableCardPicking();
        // Init next phase
        NextPhase();

            
    }
    /// <summary>
    /// Player and enemy select desired card to use in resolve battle phase. Wait players select card using game HUD. Enemy picks its card conform its attack order.
    /// </summary>
    public void PlanningPhase()
    {
        // If a card was selected
        if(player.hand.selectedCard!= null)
        {
            // Verifies if has eneough energy and uses
            if(player.hand.selectedCard.cost <= player.energy)
            {
                // TODO: Consume card energy
                //player.AddEnergy(- player.hand.selectedCard.cost);
                // Use enemy selected card
                enemySelectedCard = enemyManager.currentEnemy.UseCurrentCard();
                // Use player selected card
                playerSelectedCard = player.hand.UseCurrentCard();
                // Start battle between player and enemiy cards
                battleGUI.StartBattle(playerSelectedCard, enemySelectedCard);  
                // Disable card picking during battle
                player.hand.DisableCardPicking();
                // Advance to next phase
                NextPhase();
            }
            // Pick another card
            else
            {
                Debug.Log("Not enough energy");
                // Unselect current card
                player.hand.selectedCard = null;
            }
           
        }
    }
    /// <summary>
    /// During battle phase, continuously check if the battle animation has finished
    /// </summary>
    public void BattlePhase()
    {
        // Check if battle animation has finished
        if (battleGUI.endBattle)
        {
            Debug.Log("EndBattle");
            // Advance to next phase
            NextPhase();
        }
       
    }

    /// <summary>
    /// Resolve battle comparing both card choices. Updates player and enemy hp based on the results.
    /// </summary>
    public void ResolveBattlePhase()
    {

        // todo: move cards to battle area
        // Judge player and enemy cards and calculate the resulting damage/heal for both player and enemy
        int[] battleResult = battleJudge.ResolveBattle(playerSelectedCard,enemySelectedCard);
        // Log results
        Debug.Log(battleResult[0].ToString() + battleResult[1].ToString() + battleResult[2].ToString() + battleResult[3].ToString());
        // Process battle results to apply damage/heal if necessary
        ProcessBattleResult(battleResult); 
        // Advance to next phase
        NextPhase();

    }
    /// <summary>
    /// Clears card choices and advance for begin turn phase
    /// </summary>
    public void EndTurnPhase()
    {
        // todo: discard cards
        // Clear enemy's and player's selected cards
        playerSelectedCard = null;
        enemySelectedCard = null;
        // Increment turn
        turnCounter++;
        // Add 1 energy per turn, max 10
        player.AddEnergy(energyPerTurn + Mathf.Clamp(turnCounter, 1, 9));
        // Max energy 10
        if(player.energy > 10)
        {
            player.SetEnergy(10);
        }

        // Enable cards from next rarity level according to the current enemy counter if there is still a level to enable
        if (enemyManager.currentEnemyOrder < cardDraft.Length)
            cardDraft[enemyManager.currentEnemyOrder] = true;
        // blocks normal and refined after the second enemy
        else if (enemyManager.currentEnemyOrder > 4)
        {
            // blocks normal
            cardDraft[0] = false;
            // blocks refined
            cardDraft[1] = false;
        }
        // Advance to next phase
        NextPhase();
    }



    /// <summary>
    /// Load game over scene
    /// </summary>
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    /// <summary>
    /// Aapplies damage and recovery for enemy and player and notificates both managers in case of defeat
    /// </summary>
    /// <param name="battleResult">Array containing the consequences of the battle for the player and the enemy</param>
    public void ProcessBattleResult(int[] battleResult)
    {
        // Apply damage to player
        player.AddDamage(battleResult[0]);
        // Apply damage to enemy
        enemyManager.currentEnemy.AddHP( battleResult[1]);   
        // Check if hp has fallen below or is equal 0
        if(player.hp <=0)
        {
            // Execute Game over
            GameOver();
        }
        // If player is still alive
        else
        {
            // Recover HP
            player.AddDamage( battleResult[2] ); 

        }
        // If monster hp is equal or below 0, it is defeated
        if (enemyManager.currentEnemy.currentHealthPoints <= 0)
        {
            Debug.Log("Monster defeated");
           // Go to next enemy
            if (enemyManager.NextEnemy())   
            {
                // Check if next monster is a boss
                if (enemyManager.currentEnemy.enemyType == EnemyType.Boss)
                {
                    // Activate boss background
                    bossBackground.SetActive(true); 
                }
                // continue to next game phase
                NextPhase();    
            }
            // If there is no more monsters
            else
            {
                // Game Over
                GameOver();
            }
            
        }
        // If enemy  still has remaining hp
        else 
        {
            // Apply any resulting healing from the battle to the enemy
            enemyManager.currentEnemy.AddHP(battleResult[3]);
        }
        Debug.Log("After Battle - Player HP: " + player.hp);
        Debug.Log("After Battle - Enemy HP: " + enemyManager.currentEnemy.currentHealthPoints);

    }


}
