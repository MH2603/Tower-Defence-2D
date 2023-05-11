using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    [SerializeField]
    public float speed;

    [SerializeField]
    public int idPos;

    public Vector2 distanceRdTarget = new Vector2( 0.05f , 0.3f);

    [HideInInspector]
    public bool Stop = false;

    Transform[] points;

    Rigidbody2D rb;
    [SerializeField] Vector3 posRd;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        points = ManagerPoints.instance.points;

        RdPosTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<BaseEnemy>().isDeathing && !Stop ) Move();
        else rb.velocity = Vector2.zero;
    }

    void RdPosTarget()
    {
        posRd.x = points[idPos].position.x + Random.Range(distanceRdTarget.x, distanceRdTarget.y);
        posRd.y = points[idPos].position.y + Random.Range(distanceRdTarget.x, distanceRdTarget.y);
    }

    void Move()
    {
        

        Vector2 dir = posRd - transform.position;
        dir.Normalize();
        rb.velocity = dir * speed;  

        if (Vector2.Distance(this.transform.position, posRd) <= 0.1f )
        {
            if (idPos == points.Length)
            {
                GameManager.instance.enemies.Remove(this.gameObject);
                Destroy(this.gameObject);

                ManagerSpawn.instance.CheckTurn();  

                player_HP player = GameObject.FindObjectOfType<player_HP>();
                player.ApplyDame(1);

                return;
            }

            RdPosTarget();
            idPos++;
        }
    }
}
