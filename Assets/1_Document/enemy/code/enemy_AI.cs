using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    [SerializeField]
    public float speed;

    [SerializeField]
    public int pos;

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

        if (Vector2.Distance(this.transform.position, points[pos].position) < 0.2f)
        {
            if (pos == 6)
            {
                GameManager.instance.enemies.Remove(this.gameObject);

                Destroy(this.gameObject);

            }

            pos++;
        }
    }
}
