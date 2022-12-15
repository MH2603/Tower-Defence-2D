using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    [SerializeField]
    public float speed;

    [SerializeField]
    public int pos;

    public Vector2 distanceNextPoss = new Vector2( 0.05f , 0.3f);

    [HideInInspector]
    public bool Stop = false;

    Transform[] points;

    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        points = ManagerPoints.instance.points;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<BaseEnemy>().isDeathing && !Stop ) Move();
        else rb.velocity = Vector2.zero;
    }

    void Move()
    {
        Vector2 dir = points[pos].position - transform.position;
        dir.Normalize();
        rb.velocity = dir * speed;  

        if (Vector2.Distance(this.transform.position, points[pos].position) < Random.Range(distanceNextPoss.x, distanceNextPoss.y) )
        {
            if (pos == 6)
            {
                GameManager.instance.enemies.Remove(this.gameObject);
                Destroy(this.gameObject);

                ManagerSpawn.instance.CheckTurn();  

                player_HP player = GameObject.FindObjectOfType<player_HP>();
                player.ApplyDame(1);


            }

            pos++;
        }
    }
}
