using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bomb_Blue : MonoBehaviour
{
    [SerializeField]
    private Transform spriteCircle;

    [SerializeField]
    private ParticleSystem effect;

    [SerializeField]
    private Collider2D collider2D;

    public float timeDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        spriteCircle.DOScale(new Vector3(1,1,1), timeDelay).SetEase(Ease.InOutSine).OnComplete( () =>
        {
            Attack();
        });

    }

    void OnTriggerEnter2D(Collider2D other)
    {
  

        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.SendMessage("ApplyDame", 1);

            collider2D.enabled = false;
        }


        if (other.gameObject.tag == "Player")
        {
            if (!other.gameObject.GetComponent<player_HP>().invisible)
            {
                other.gameObject.SendMessage("ApplyDame", 1);

                collider2D.enabled = false;

            }

        }
    }


    void Attack()
    {
        collider2D.enabled = true;

        effect.Play();

        Invoke("OffCollider", 0.1f);
        Invoke("Die", 0.5f);

    }

    void OffCollider()
    {
        collider2D.enabled = false;
    }

    void Die()
    {
        CancelInvoke("Die");
        this.gameObject.Recycle();
    }


    
}
