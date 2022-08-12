using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public GameObject shadow;
    public float layer;

    public GameObject managerAsset;
    ManagerItem managerItem;

    public bool isBuilding;
    public bool isbuilder;

    // Start is called before the first frame update
    void Start()
    {
        managerAsset = GameObject.Find("ManagerAsset");
        managerItem = managerAsset.GetComponent<ManagerItem>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) BuildTower();
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
        if( isBuilding && !isbuilder)
        {
            isbuilder = true;

            shadow.SetActive(false) ;

            Vector3 pos = this.transform.position;
            //pos.y += 0.3f;
            GameObject tower = Instantiate(managerItem.Tower[managerItem.WhatIsBuilding], pos, Quaternion.identity);
            
            tower.GetComponent<SpriteRenderer>().sortingOrder = -(int)(layer);

            managerItem.Items[managerItem.WhatIsBuilding].x -= managerItem.Items[managerItem.WhatIsBuilding].y;

            managerItem.WhatIsBuilding = -1;

            managerItem.OnGrid(false);

        }
    }

    
}
