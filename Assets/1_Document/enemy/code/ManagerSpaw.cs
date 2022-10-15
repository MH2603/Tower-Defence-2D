using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpaw : MonoBehaviour
{


    public Turn[] turns;

    public GameObject buttonFight;

    public int WhatIsTurn ;

    public bool isTurning;
    bool isChecking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( isChecking ) CheckTurn();

        GameManager.instance.isInTurn = isTurning;
    }


    public void NextTurn() // ButtonFight kick
    {
        turns[WhatIsTurn].SpawEnemies();
        WhatIsTurn++;

        isChecking = false;
        isTurning = true;
        buttonFight.SetActive(false);
        Invoke("OnCheck", 3);
    }

    void OnCheck() // call by Invoke
    {
        isChecking = true;
    }

    void CheckTurn()
    {
        if (WhatIsTurn == 0 || GameManager.instance.enemies.Count == 0 && turns[WhatIsTurn - 1].numEnemyInTurn == 0) //turns[WhatIsTurn - 1].transform.childCount == 0
        {
            buttonFight.SetActive(true);
            isTurning = false;   
        }
        
    }
   
    
    
}



