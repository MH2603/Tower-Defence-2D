using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{

    public GameObject[] items;
    public int[] dropCount;


    public Animator anima;

    public float  dropRadius = 0.05f ;

    public float HP = 1;

    public bool isDeathing;
    // Start is called before the first frame update


    private void Awake()
    {
        
    }

    void  Start()
    {
        GameManager.instance.enemies.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void DropItem(int i)
    {
        
        while ( dropCount[i] > 0)
        {
            dropCount[i]--;
            Vector3 pos = transform.position;
            pos.x += dropRadius * Random.Range(-15,10);
            pos.y += dropRadius * Random.Range(-10,15);

            Instantiate(items[i], pos, Quaternion.identity);
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


        GameManager.instance.enemies.Remove(this.gameObject);

        Destroy(gameObject, 0.41666666f);
    }
}
