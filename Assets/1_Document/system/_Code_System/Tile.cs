using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{

    public GameObject shadow;
    public float layer;

    ManagerAsset managerAsset;
    GameObject tower;

    public bool isBuilding;
    public bool isbuilder;
    int WhatIsBuilder = -1;

    [Header("* Vfx")]
    public ParticleSystem fxBuild;
    public List<ParticleSystem> listFxDestroy;

    [Header("* Sound")]
    public AudioClip buildSound;
    public AudioClip destroySound;

    ParticleSystem fx;

    private void OnEnable()
    {
        shadow.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        managerAsset = GameManager.instance.managerAsset;

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
        if( isBuilding && !isbuilder && managerAsset.WhatIsBuilding >= 0)
        {
            if (!GameManager.instance.UseEnergy( managerAsset.countEnergy[managerAsset.WhatIsBuilding]))
            {
                return;
            }


            isbuilder = true;

            shadow.SetActive(false) ;

            Vector3 pos = this.transform.position;

            //pos.y += 0.3f;
            tower = Instantiate(managerAsset.Tower[managerAsset.WhatIsBuilding], pos, Quaternion.identity);
            tower.transform.localScale = new Vector3(0,0,0);
            tower.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
            tower.GetComponent<SpriteRenderer>().sortingOrder = -(int)(layer);
        
            managerAsset.Items[managerAsset.WhatIsBuilding].x -= managerAsset.Items[managerAsset.WhatIsBuilding].y;

            fx = fxBuild.Spawn(this.transform.position, Quaternion.identity);
            fx.Play();
            GameManager.instance.OffObject(fx.gameObject, 0.5f);

            SoundManager.Instance.ShowSound(buildSound);

            WhatIsBuilder = managerAsset.WhatIsBuilding;
            isBuilding = false;

            managerAsset.SetMouse(0);
            managerAsset.WhatIsBuilding = -1;
            managerAsset.OnGrid(false);

            GameManager.instance.Gui.ShowTowerBuilding(managerAsset.WhatIsBuilding);

        }


    }

    

    void DesTroyTower()
    {
        if( isbuilder  && isBuilding && managerAsset.WhatIsBuilding == -2)
        {
            tower.SendMessage("Death");

            GameManager.instance.UseEnergy(-managerAsset.countEnergy[WhatIsBuilder]);

            fx = listFxDestroy[WhatIsBuilder].Spawn(this.transform.position + listFxDestroy[WhatIsBuilder].transform.localPosition
                                                    , Quaternion.identity);
            fx.Play();
            GameManager.instance.OffObject(fx.gameObject, 1f);

            SoundManager.Instance.ShowSound(destroySound, 0.4f);

            WhatIsBuilder = -1;

            isbuilder = false;

            isBuilding = false;
            shadow.SetActive(false);

            

            managerAsset.SetMouse(0);
            managerAsset.WhatIsBuilding = -1;
            managerAsset.OnGrid(false);

            GameManager.instance.Gui.ShowTowerBuilding(managerAsset.WhatIsBuilding);
        }
    }

    

    
}
