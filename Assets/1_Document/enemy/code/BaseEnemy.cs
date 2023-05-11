using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseEnemy : MonoBehaviour
{

    public GameObject[] items;
    public int[] dropCount;


    public Animator anima;

    public float  dropRadius = 0.05f ;

    public float HP = 1;

    public bool isDeathing;

    void  Start()
    {
        GameManager.instance.enemies.Add(this.gameObject);
    }


    void DropItem(int i)
    {

        for( int j = 0; j < dropCount[i]; j++)
        {
            Vector3 pos = transform.position;
            pos.x += dropRadius * Random.Range(-25, 20);
            pos.y += dropRadius * Random.Range(-20, 25);

            GameObject item = items[i].Spawn(this.transform.position, Quaternion.identity);
            float force = Random.Range(0.1f, 0.5f);
            int countJump = Random.Range(0, 4);
            item.transform.DOJump(pos, force, countJump, 1.5f);
        }

    }

    void DropItems()
    {
        for(int i = 0; i < items.Length; i++)
        {
            DropItem(i);
        }
    }


    void ApplyDame(int value) // Get send messenger from bullet
    {

        if (HP <= 0) return;

        HP -= value;

        if (HP <= 0) Death();
        else anima.SetBool("hit", true);
       
    }





    void Death() // Call by tile
    {
        this.GetComponent<Collider2D>().enabled = false;

        anima.SetBool("death",true);
        DropItems();

        isDeathing = true;

        GameManager.instance.RemoveEnemy(gameObject);

        ManagerSpawn.instance.CheckTurn();

        Destroy(gameObject, 0.41666666f);
    }
}
