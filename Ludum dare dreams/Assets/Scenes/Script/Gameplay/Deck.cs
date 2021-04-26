using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Deck : MonoBehaviour{
    
    public CardSO[] deckNormal;
    public CardSO[] deckRefined;
    public CardSO[] deckUnique;
    public CardSO[] deckElite;
    public CardSO[] deckSuper;

    public bool drawn = false;    

    public void DrawCard(bool normal, bool refined, bool unique,bool elite, bool super){
              
        if(drawn==true){
            if(normal == true && refined == true)
            {

            }
            drawn = false;
        }
       
    }
    


}