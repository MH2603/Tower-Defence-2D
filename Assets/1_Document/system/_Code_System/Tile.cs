using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public GameObject shadow;
    public float layer;

    public GameObject managerAsset;
    ManagerItem managerItem;

    GameObject tower;

    public bool isBuilding;
    public bool isbuilder;
    float WhatIsBuilder = -1;

    // Start is called before the first frame update
    void Start()
    {
        managerAsset = GameObject.Find("ManagerAsset");
        managerItem = managerAsset.GetComponent<ManagerItem>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Kick mouse left
        {
            BuildTower();
            DesTroyTower();
        }
    }
    
    void OnMouseEnter()
    {
        shadow.SetActive(true);
        isBuilding = true;

        
        
    }

    void OnMouseExit()
    {
        shadow.SetActive(false);
        isBuilding = false;
    }

    void BuildTower()
    {
        if( isBuilding && !isbuilder && managerItem.WhatIsBuilding >= 0)
        {
            isbuilder = true;

            shadow.SetActive(false) ;

            Vector3 pos = this.transform.position;
            //pos.y += 0.3f;
            tower = Instantiate(managerItem.Tower[managerItem.WhatIsBuilding], pos, Quaternion.identity);
            
            tower.GetComponent<SpriteRenderer>().sortingOrder = -(int)(layer);

            managerItem.Items[managerItem.WhatIsBuilding].x -= managerItem.Items[managerItem.WhatIsBuilding].y;

            WhatIsBuilder = managerItem.WhatIsBuilding;
            isBuilding = false;

            managerItem.SetMouse(0);
            managerItem.WhatIsBuilding = -1;
            managerItem.OnGrid(false);

            GameManager.instance.GUI.ShowTowerBuilding(managerItem.WhatIsBuilding);

        }


    }


    void DesTroyTower()
    {
        if( isbuilder  && isBuilding && managerItem.WhatIsBuilding == -2)
        {
            tower.SendMessage("Death");

            isbuilder = false;

            isBuilding = false;
            shadow.SetActive(false);

            managerItem.SetMouse(0);
            managerItem.WhatIsBuilding = -1;
            managerItem.OnGrid(false);

            GameManager.instance.GUI.ShowTowerBuilding(managerItem.WhatIsBuilding);
        }
    }

    
}
