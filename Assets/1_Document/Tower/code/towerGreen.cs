using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerGreen : towerRed
{


    protected override void SpawBullet()
    {
        if (managerSpaw.isTurning) // only spaw bullet when Turning
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject newBullet = bullet.Spawn(this.transform.position, Quaternion.identity);

                newBullet.name = "bullet" + i;

                Vector2 v = new Vector2(Mathf.Cos(Mathf.PI * i / 4), Mathf.Sin(Mathf.PI * i / 4));
                //v.Normalize();
                newBullet.GetComponent<Rigidbody2D>().velocity = v * speedBullet;

            }
        }
            
        Invoke("SpawBullet", timeShot);
    }
}
