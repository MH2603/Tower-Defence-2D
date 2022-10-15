using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bomb_Blue : MonoBehaviour
{
    [SerializeField]
    private Transform spriteCircle;

    [SerializeField]
    private GameObject effect;

    [SerializeField]
    private Collider2D collider2D;


    [SerializeField]
    private float timeDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        spriteCircle.DOScale(new Vector3(1,1,1), timeDelay).SetEase(Ease.InOutSine);

        Invoke("Attack", timeDelay);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
  

        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.SendMessage("ApplyDame", 1);
         

            Destroy(gameObject);

           
        }


        if (other.gameObject.tag == "Player")
        {
            if (!other.gameObject.GetComponent<player_HP>().invisible)
            {
                other.gameObject.SendMessage("ApplyDame", 1);
                Destroy(gameObject);

            }

        }
    }


    void Attack()
    {
        collider2D.enabled = true;

        effect.SetActive(true);
        effect.transform.parent = null;
        Destroy(effect, 1f);

        Destroy(this.gameObject,0.1f);

    }


    
}
