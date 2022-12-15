using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUP : MonoBehaviour
{

    Transform player;
    GameObject ManagerAsset;

    public int intCoin;

    public float speed = 4;
    public float pickUpDistance = 2.5f;
    public float destroyTime = 5f;


    SpriteRenderer image;

    bool seen,WillDestroy;
    void Awake()
    {
        player = GameObject.Find("player").GetComponent<Transform>();
        ManagerAsset = GameObject.Find("ManagerAsset");

        image = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        destroyTime -= Time.deltaTime;

        if(destroyTime < 0) Destroy(gameObject);
     
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
                ManagerAsset.SendMessage("SetItemCount", intCoin);
                seen = true;
            }

            GameManager.instance.Score += (intCoin + 1) * 10; // Save Data

            Destroy(gameObject);
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
