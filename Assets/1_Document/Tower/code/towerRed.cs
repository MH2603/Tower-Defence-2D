using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerRed : MonoBehaviour
{

    public GameObject bullet;
    protected ManagerSpaw managerSpaw;

    public float timeShot = 2;
    public float speedBullet = 1;

    // Start is called before the first frame update
    protected void Start()
    {
        Invoke("SpawBullet", timeShot); 
        
        managerSpaw = GameObject.Find("ManagerSpaw").GetComponent<ManagerSpaw>();
    }


    protected virtual void SpawBullet()
    {
        if(managerSpaw.isTurning)
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject newBullet = bullet.Spawn(this.transform.position, Quaternion.identity);

                newBullet.name = "bullet" + i;
            
                Vector2 v = new Vector2(Mathf.Cos(Mathf.PI * i / 2), Mathf.Sin(Mathf.PI * i / 2));
                //v.Normalize();
                newBullet.GetComponent<Rigidbody2D>().velocity = v * speedBullet;

            }
        }
        
        Invoke("SpawBullet", timeShot);
    }
}
