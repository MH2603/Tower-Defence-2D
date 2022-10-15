using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Item : MonoBehaviour
{

    public GameObject[] items;
    public int[] dropCount;

    public float dropRadius = 0.05f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void DropItem(int i)
    {

        while (dropCount[i] > 0)
        {
            dropCount[i]--;
            Vector3 pos = transform.position;
            pos.x += dropRadius * Random.Range(-15, 10);
            pos.y += dropRadius * Random.Range(-10, 15);

            Instantiate(items[i], pos, Quaternion.identity);
        }
    }

    void DropItems()
    {
        for (int i = 0; i < items.Length; i++)
        {
            DropItem(i);
        }
    }

    void Death()
    {
        
        DropItems();

        Destroy(gameObject);
    }

}