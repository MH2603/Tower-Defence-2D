using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipMove : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Move());
    }


    IEnumerator Move()
    {
        while (true)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            this.transform.DOMoveX(12, 15f);

            float num1 = Random.Range(5, 10);
            yield return new WaitForSeconds(num1 + 15);
            this.GetComponent<SpriteRenderer>().flipX = true;


            this.transform.DOMoveX(-12, 10f);

            float num2 = Random.Range(5, 10);
            yield return new WaitForSeconds(num2 + 15);
        }
        
    }
}
