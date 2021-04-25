using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GamePhases {BEGIN_TURN, PLANNING, RESOLVE_BATTLE, END_TURN}
public class GamePhasesManager : MonoBehaviour
{
    public GamePhases phase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextPhase()
    {
         phase = phase != GamePhases.END_TURN? phase+1: GamePhases.BEGIN_TURN;
    }
}
