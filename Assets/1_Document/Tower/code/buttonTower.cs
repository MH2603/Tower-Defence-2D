using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTower : MonoBehaviour
{
    
    public TextMeshProUGUI textCount;
    public TextMeshProUGUI textEnergy;
    public GameObject fxBg;
    public GameObject tutorial;
    public Image imageBg;
    public Image iconItem;
    public Image iconTower;
    [Header("* Color text")]
    public Color colorEnough;
    public Color colorNotEnough;

    ManagerAsset managerAsset;
    Button myBtn;

    public int WhatIsButton = 0;


    public void Init()
    {
        managerAsset = GameManager.instance.managerAsset;
        myBtn = GetComponent<Button>();

        myBtn.onClick.AddListener(() => managerAsset.OnBuildingTower(WhatIsButton));

        textEnergy.text = managerAsset.countEnergy[WhatIsButton].ToString();
    }

    // Update is called once per frame
    void Update()
    {     
        UpdateItemCount();
    }

    void OnMouseEnter()
    {
        if (managerAsset.WhatIsBuilding == -1) managerAsset.SetMouse(1);
        tutorial.SetActive(true);
    }

    void OnMouseExit()
    {
        if (managerAsset.WhatIsBuilding == -1) managerAsset.SetMouse(0);
        tutorial.SetActive(false);
    }


    void UpdateItemCount()
    {
        textCount.text = managerAsset.Items[WhatIsButton].x + "/" + managerAsset.Items[WhatIsButton].y;
        if(managerAsset.Items[WhatIsButton].x < managerAsset.Items[WhatIsButton].y) textCount.color = colorNotEnough;
        else textCount.color = colorEnough;

        int energy = -GameManager.instance.currentEnergy + GameManager.instance.maxEnergy;
        if( int.Parse(textEnergy.text) <=  energy ) textEnergy.color = colorEnough;
        else textEnergy.color = colorNotEnough;

        if(managerAsset.Items[WhatIsButton].x >= managerAsset.Items[WhatIsButton].y)
        {
            fxBg.SetActive(true);   
        }else fxBg.SetActive(false);
    }




}


