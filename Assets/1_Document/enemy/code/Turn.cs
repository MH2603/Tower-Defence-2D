using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{

    public GameObject[] enemies;

    public int[] enemyCount;

    public Vector2[] timeSpaw;

    void Start()
    {
        
    }


    void Update()
    {
        
    }


    public void SpawEnemies()
    {
        Debug.Log("spawEnemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            for(int j = 0;j < enemyCount[i];j++ )
            {
                //Invoke("SpawEnemy", j*timeSpaw[i] + 1);
                StartCoroutine( SpawEnemy( j * timeSpaw[i].x + timeSpaw[i].y, i) );
            }
        }
    }

    IEnumerator SpawEnemy(float time,int WhatIsEnemy)
    {
        yield return new WaitForSeconds(time);

        GameObject enemy = Instantiate( enemies[WhatIsEnemy] , this.transform.position,Quaternion.identity);
        enemy.transform.SetParent(this.transform);
    }
}