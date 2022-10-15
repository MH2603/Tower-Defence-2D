using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerRed : MonoBehaviour
{

    public GameObject bullets;
    ManagerSpaw managerSpaw;

    public float timeShot = 2;
    public float speedBullet = 1;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawBullet", timeShot); 
        
        managerSpaw = GameObject.Find("ManagerSpaw").GetComponent<ManagerSpaw>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawBullet()
    {
        if(managerSpaw.isTurning)
        {
            for (int i = 0; i < 4; i++)
            {
                //GameObject bullet = Instantiate(bullets, this.transform.position, Quaternion.identity);

                GameObject bullet = ObjectPool.instance.GetPooledObject();
                bullet.transform.position = this.transform.position;
                bullet.SetActive(true);

                bullet.name = "bullet" + i;
                //bullet.transform.SetParent(this.transform);

                Vector2 v = new Vector2(Mathf.Cos(Mathf.PI * i / 2), Mathf.Sin(Mathf.PI * i / 2));
                //v.Normalize();
                bullet.GetComponent<Rigidbody2D>().velocity = v * speedBullet;

            }
        }
        
        



        Invoke("SpawBullet", timeShot);
    }
}
