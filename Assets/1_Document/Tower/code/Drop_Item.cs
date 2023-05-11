using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Drop_Item : MonoBehaviour
{

    public GameObject[] items;
    public int[] dropCount;

    public float dropRadius = 0.05f;

    void DropItem(int i)
    {

        for (int j = 0; j < dropCount[i]; j++)
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