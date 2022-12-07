using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anima;
    // Start is called before the first frame update
    private void OnEnable()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Set(bool i)
    {
        yield return new WaitForSeconds(0.333333f);

        this.gameObject.Recycle();
    }

    void DesTroy()
    {
        rb.velocity = Vector3.zero;
        this.gameObject.GetComponent<Collider2D>().enabled = false; 

        anima.SetBool("desTroy", true);

        StartCoroutine(Set(false));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "blockBullet") DesTroy();

        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.SendMessage("ApplyDame", 1);
            DesTroy();
        }


        if(other.gameObject.tag == "Player")
        {
            if ( !other.gameObject.GetComponent<player_HP>().invisible)
            {
                other.gameObject.SendMessage("ApplyDame", 1);
                DesTroy();
            }

        }
    }

   
}
