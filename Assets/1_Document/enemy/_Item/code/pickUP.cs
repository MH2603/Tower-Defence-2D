using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUP : MonoBehaviour
{

    Transform player;

    public int idCoin;

    public float speed = 4;
    public float pickUpDistance = 2.5f;
    public float destroyTime = 5f;
    float curretDestroyTime;
    
    SpriteRenderer image;

    bool seen,WillDestroy;

    private void OnEnable()
    {
        curretDestroyTime = destroyTime;
        seen = false;
        CancelInvoke("OffImage");
        CancelInvoke("OnImage");
   
    }

    private void OnDisable()
    {
        image.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.playerOb.transform;

        image = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        curretDestroyTime -= Time.deltaTime;

        if(curretDestroyTime < 0) this.gameObject.Recycle();
     
        if(destroyTime < 1.5f && !WillDestroy )
        {
            Invoke("OffImage",0f);
            WillDestroy = true;
        }

        float distance = Vector3.Distance(transform.position, player.position);
        if(distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if(distance < 0.01)
        {
            if (!seen) 
            {
                GameManager.instance.managerAsset.SetItemCount(idCoin);

                seen = true;
            }

            GameManager.instance.Score += (idCoin + 1) * 5; // Save Data

            this.gameObject.Recycle();
        }
    }


    void OffImage()
    {
        image.enabled = false;
        Invoke("OnImage", 0.1f);
    }

    void OnImage()
    {
        image.enabled = true;
        Invoke("OffImage", 0.1f);
    }

}
