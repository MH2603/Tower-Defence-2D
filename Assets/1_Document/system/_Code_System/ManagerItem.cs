using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerItem : MonoBehaviour
{



    public GameObject[] Tower;
    public Texture2D[] cursors;

    public Vector2[] Items ;

    public int WhatIsBuilding = -1;

    public GameObject grid;

    // Start is called before the first frame update
    void Start()
    {
        SetMouse(0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) SetMouse(0);
        if (Input.GetMouseButtonDown(1)) ExitBuilding();
    }


    void SetItemCount( int intCoin) // Use get messsger from Item
    {
        Items[intCoin].x ++;
    }

    public void SetMouse(int i) 
    {
        Cursor.SetCursor(cursors[i], Vector2.zero, CursorMode.ForceSoftware);
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
    }


    public void DestroyTower() // Button Call
    {
        SetMouse(3);
        WhatIsBuilding = -2;
        OnGrid(true);
    } 

    public void OnBuildingRed() // Button On
    {
        if (Items[0].x >= Items[0].y)
        {
            WhatIsBuilding = 0;
            SetMouse(2);
            OnGrid(true);
        }
    }

    public void OnBuildingGreen() // Button On
    {
        if (Items[1].x >= Items[1].y)
        {
            WhatIsBuilding = 1;
            SetMouse(2);
            OnGrid(true);
        }
    }

    public void OnBuildingBlue() // Button On
    {
        if (Items[2].x >= Items[2].y)
        {
            WhatIsBuilding = 2;
            SetMouse(2);
            OnGrid(true);
        }
    }
}
