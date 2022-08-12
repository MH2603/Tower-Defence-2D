using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonTower : MonoBehaviour
{
    

    public Text CountText;
    public Text MaxText;

    public GameObject tutorial;

    public ManagerItem managerItem;

    public int WhatIsButton = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {     
        UpdateItemCount();
    }

    



    void OnMouseEnter()
    {
        if (managerItem.WhatIsBuilding == -1) managerItem.SetMouse(1);
        tutorial.SetActive(true);
    }

    void OnMouseExit()
    {
        if (managerItem.WhatIsBuilding == -1) managerItem.SetMouse(0);
        tutorial.SetActive(false);
    }


    void UpdateItemCount()
    {
        CountText.text = managerItem.Items[WhatIsButton].x.ToString();
        MaxText.text = "/ " + managerItem.Items[WhatIsButton].y.ToString();
    }
   

  
    
}
