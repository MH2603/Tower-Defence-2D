using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ManagerSpawn : MonoBehaviour
{
    public static ManagerSpawn instance;

    public Turn[] MainTurns;
    public Turn[] LastTurns;

    public GameObject buttonFight;
    public GameObject iconEnemy;
    public GameObject iconHome;

    public int WhatIsTurn;

    public bool isTurning;

    public bool isLastTurns;

    [Header("* Sound Asset")]
    public AudioClip endTurnSound;
    public AudioClip startTurnSound;

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

            WhatIsTurn++; // beacuse checkTurns

        }
        else
        {
            MainTurns[WhatIsTurn].CallSpawnTurnEnemy();
            WhatIsTurn++;
        }

        SoundManager.Instance.PlaySound(startTurnSound);
        iconEnemy.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        iconHome.transform.DOScale(new Vector3(0, 0, 0), 0.5f);

        GameManager.instance.LevelFinish++; // save data
        GameManager.instance.Gui.prepareLevel.text = "Level "  + GameManager.instance.LevelFinish;

        
        isTurning = true;

        //buttonFight.SetActive(false);
        buttonFight.transform.DOMoveY(buttonFight.transform.position.y - 3, 0.5f);
    }

    
    public void CheckTurn()
    {
        if ( GameManager.instance.enemies.Count == 0 && MainTurns[WhatIsTurn - 1].numEnemyNotSpawn == 0) //turns[WhatIsTurn - 1].transform.childCount == 0
        {
            //buttonFight.SetActive(true);
            buttonFight.transform.DOMoveY(buttonFight.transform.position.y + 3, 0.5f);
            isTurning = false;

            SoundManager.Instance.ShowSound(endTurnSound);
            iconEnemy.transform.DOScale(new Vector3(-1, 1, 1), 0.5f);
            iconHome.transform.DOScale(new Vector3(1, 1, 1), 0.5f);

        }
        
    }
   
    
    
}



