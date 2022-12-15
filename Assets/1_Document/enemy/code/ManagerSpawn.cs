using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawn : MonoBehaviour
{
    public static ManagerSpawn instance;

    public Turn[] MainTurns;
    public Turn[] LastTurns;

    public GameObject buttonFight;

    public int WhatIsTurn;

    public bool isTurning;

    public bool isLastTurns;

    private void Awake()
    {
        instance = this;    
    }

    public void NextTurn() // ButtonFight kick
    {
        if( WhatIsTurn >=  MainTurns.Length || isLastTurns  )
        {
            isLastTurns = true;
            
            WhatIsTurn = Random.Range(0, LastTurns.Length);
            LastTurns[WhatIsTurn].CallSpawnTurnEnemy();

            WhatIsTurn++; // beacuse checkTurn

        }
        else
        {
            MainTurns[WhatIsTurn].CallSpawnTurnEnemy();
            WhatIsTurn++;
        }

        GameManager.instance.LevelFinish++; // save data
        GameManager.instance.GUI.prepareLevel.text = "Level "  + GameManager.instance.LevelFinish;

        
        isTurning = true;
        buttonFight.SetActive(false);
    }

    
    public void CheckTurn()
    {
        if ( GameManager.instance.enemies.Count == 0 && MainTurns[WhatIsTurn - 1].numEnemyNotSpawn == 0) //turns[WhatIsTurn - 1].transform.childCount == 0
        {
            buttonFight.SetActive(true);
            isTurning = false;   
        }
        
    }
   
    
    
}



