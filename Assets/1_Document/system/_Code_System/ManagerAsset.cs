using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


public class ManagerAsset : MonoBehaviour
{

    public List<DataTower> listBtnTower;

    public GameObject[] Tower;
    public Texture2D[] cursors;

    public List<int> countEnergy;

    public Vector2[] Items ;

    public int WhatIsBuilding = -1;

    public GameObject grid;

    [Header("* Sound")]
    public AudioClip pickCoinSound;
    public AudioClip clickChoseTowerSound;

    // Start is called before the first frame update
   
    public void Init()
    {
        SetMouse(0);

        SetUpListBtnTower();
    }

    void SetUpListBtnTower()
    {
        for(int i=0; i< listBtnTower.Count; i++)
        {
            SetUpBtnTower(listBtnTower[i],i);
        }
    }

    void SetUpBtnTower(DataTower dataTower,int id )
    {
        dataTower.btnTower.imageBg.sprite = dataTower.imageBg;
        dataTower.btnTower.iconItem.sprite = dataTower.iconItem;
        dataTower.btnTower.iconTower.sprite = dataTower.iconTower;

        dataTower.btnTower.WhatIsButton = id;
        dataTower.btnTower.Init();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) SetMouse(0);
        if (Input.GetMouseButtonDown(1)) ExitBuilding();
    }


    public void SetItemCount( int intCoin) // Use get messsger from Item
    {
        Items[intCoin].x ++;
        SoundManager.Instance.ShowSound(pickCoinSound,0.2f);
    }

    public void SetMouse(int i) 
    {
        
        Cursor.SetCursor(cursors[i], Vector2.zero, CursorMode.ForceSoftware );
        
    }

    public void OnGrid(bool i)
    {
        grid.SetActive(i);
    }

   


    void ExitBuilding()
    {
        SetMouse(0);
        WhatIsBuilding = -1;
        OnGrid(false);

        GameManager.instance.Gui.ShowTowerBuilding(WhatIsBuilding);

    }


    public void DestroyTower() // Button Call
    {
        SetMouse(3);
        WhatIsBuilding = -2;
        OnGrid(true);

        GameManager.instance.Gui.ShowTowerBuilding(4);
    } 

    //public void OnBuildingRed() // Button On
    //{
    //    if (Items[0].x >= Items[0].y)
    //    {
    //        WhatIsBuilding = 0;
    //        SetMouse(2);
    //        OnGrid(true);
    //    }
    //}

    //public void OnBuildingGreen() // Button On
    //{
    //    if (Items[1].x >= Items[1].y)
    //    {
    //        WhatIsBuilding = 1;
    //        SetMouse(2);
    //        OnGrid(true);
    //    }
    //}

    //public void OnBuildingBlue() // Button On
    //{
    //    if (Items[2].x >= Items[2].y)
    //    {
    //        WhatIsBuilding = 2;
    //        SetMouse(2);
    //        OnGrid(true);
    //    }
    //}

    public void OnBuildingTower(int IDofTower) // Button On
    {
        

        if (Items[IDofTower].x >= Items[IDofTower].y)
        {
            WhatIsBuilding = IDofTower;
            SetMouse(2);
            OnGrid(true);

            GameManager.instance.Gui.ShowTowerBuilding(WhatIsBuilding);

            SoundManager.Instance.ShowSound(clickChoseTowerSound, 0.3f);
        }
    }
}

[System.Serializable]
public struct DataTower
{
    [Header("-- Btn Asset")]
    public ButtonTower btnTower;
    public Sprite imageBg;
    public Sprite iconItem;
    public Sprite iconTower;
    
}
