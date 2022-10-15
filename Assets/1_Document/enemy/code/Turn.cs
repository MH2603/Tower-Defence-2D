using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{

    public GameObject[] enemies;

    public int[] enemyCount;

    public Vector2[] timeSpaw;

    public int numEnemyInTurn = 0;

    void Start()
    {
        for(int i = 0; i < enemyCount.Length; i++)
        {
            numEnemyInTurn += enemyCount[i];
        }
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
        Vector3 pos = this.transform.position;

        pos.y += UnityEngine.Random.Range(-0.3f, 0.3f);
        enemy.transform.position = pos;

        enemy.transform.SetParent(this.transform);

        numEnemyInTurn--;

        
    }
}