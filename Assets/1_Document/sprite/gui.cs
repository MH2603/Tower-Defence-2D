using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Gui : MonoBehaviour
{
    

    [Header("GamePlay")]
    public TextMeshProUGUI prepareLevel;
    public EnergyUI energyUi; 

    [Header("Tower")]
    public Sprite[] AssetImageTower;
    public MouseUI mouseUI;
    public GameObject UiTowerBuilding;
    public Image ImageTowerBuilding;
    float saveY;


    [Header("EndGame")]
    public EndGamePopup endGamePopup;
    

  
    public void Init(int maxEnergy = 0)
    {
        energyUi.Init(maxEnergy);
        saveY = UiTowerBuilding.transform.position.y;
    }

    public void ShowEndGame()
    {
        endGamePopup.gameObject.SetActive(true);
        endGamePopup.Init(GameManager.instance.Score);
    }


    public void ShowTowerBuilding(int WhatIsBuild)
    {
        if( WhatIsBuild >= 0)
        {
            ImageTowerBuilding.sprite = AssetImageTower[WhatIsBuild];
            mouseUI.SetImage(AssetImageTower[WhatIsBuild]);
            UiTowerBuilding.transform.DOMoveY( saveY + 3, 1f);
        }
        else
        {
            Vector3 pos =  UiTowerBuilding.transform.position;
            pos.y = -210;
            UiTowerBuilding.transform.DOMoveY( saveY, 1f);
            mouseUI.OnOff(false);
        }

       
        
    }


}
