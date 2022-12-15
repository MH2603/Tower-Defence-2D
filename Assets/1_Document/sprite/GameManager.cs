using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public List<GameObject> enemies;

    

    public gui GUI;
    public float Score, LevelFinish = 1;

    void Awake()
    {
        instance = this;
    }

    public void EndGame()
    {
        // Set Data
        if( Score > PlayerPrefs.GetFloat("HighScore") ) PlayerPrefs.SetFloat("HighScore", Score);    
        if(  LevelFinish > PlayerPrefs.GetFloat("HighLevel") ) PlayerPrefs.SetFloat("HighLevel", LevelFinish);

        GUI.ShowEndGame();
    }


    
 
}
