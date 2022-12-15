using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class gui : MonoBehaviour
{
    [Header("GamePlay")]
    public Text prepareLevel;


    [Header("Tower")]
    public Sprite[] AssetImageTower;
    public GameObject UiTowerBuilding;
    public Image ImageTowerBuilding;
    float saveY;


    [Header("EndGame")]
    public GameObject EndGame;
    public Text hightScore, score, LevelFinish;


    private void Start()
    {
        saveY = UiTowerBuilding.transform.position.y;
    }

    public void ShowEndGame()
    {
        hightScore.text = PlayerPrefs.GetFloat("HighScore").ToString();
        score.text = GameManager.instance.Score.ToString();
        LevelFinish.text = GameManager.instance.LevelFinish.ToString();


        EndGame.SetActive(true);
     
    }


    public void ShowTowerBuilding(int WhatIsBuild)
    {
        if( WhatIsBuild >= 0)
        {
            ImageTowerBuilding.sprite = AssetImageTower[WhatIsBuild];

            UiTowerBuilding.transform.DOMoveY( saveY + 3, 1f);
        }
        else
        {
            Vector3 pos =  UiTowerBuilding.transform.position;
            pos.y = -210;
            UiTowerBuilding.transform.DOMoveY( saveY, 1f);
        }

       
        
    }


}
