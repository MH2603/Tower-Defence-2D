using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{

    public List<DataTurn> dataTurn;

    public int numEnemyNotSpawn = 0;

    

    

    //public void SpawEnemies()
    //{
    //    Debug.Log("spawEnemy");

    //    for (int i = 0; i < enemies.Length; i++)
    //    {
    //        for(int j = 0;j < enemyCount[i];j++ )
    //        {
    //            //Invoke("SpawEnemy", j*timeSpaw[i] + 1);
    //            StartCoroutine( SpawEnemy( j * timeSpaw[i].x + timeSpaw[i].y, i) );
    //        }
    //    }


        
    //}

    //IEnumerator SpawEnemy(float time,int WhatIsEnemy)
    //{
    //    yield return new WaitForSeconds(time);

    //    GameObject enemy = Instantiate( enemies[WhatIsEnemy] , this.transform.position,Quaternion.identity);
    //    Vector3 pos = this.transform.position;

    //    pos.y += UnityEngine.Random.Range(-0.3f, 0.3f);
    //    enemy.transform.position = pos;

    //    enemy.transform.SetParent(this.transform);

    //    numEnemyNotSpawn--;

        
    //}

   
    public void CallSpawnTurnEnemy()
    {

        numEnemyNotSpawn = 0;
        for (int i=0;i< dataTurn.Count; i++)
        {
            numEnemyNotSpawn += dataTurn[i].countEnemy;
            StartCoroutine(SpawnTypeEnemy(dataTurn[i]));
 
        }

        
    }


    IEnumerator SpawnTypeEnemy( DataTurn dataTurn)
    {
        yield return new WaitForSeconds(dataTurn.durationStart);

        for(int i=0; i < dataTurn.countEnemy; i++)
        {

            Vector3 pos = this.transform.position;
            pos.y += UnityEngine.Random.Range(-0.3f, 0.3f);

            GameObject enemy = Instantiate(dataTurn.enemy , pos, Quaternion.identity);
            enemy.transform.SetParent(this.transform);

            numEnemyNotSpawn--;

            yield return new WaitForSeconds(dataTurn.durationMid);

        }
   
    }



}

[Serializable]
public class DataTurn{
    public GameObject enemy;
    public int countEnemy;
    public float durationStart;
    public float durationMid;
}