using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_AI : MonoBehaviour
{

    ManagerPoints managerPoints;

    public enemy_HP enemy_HP;

    public float speed;

    public int pos;

    // Start is called before the first frame update
    void Start()
    {
        managerPoints = GameObject.Find("ManagerPoints").GetComponent<ManagerPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        if( !enemy_HP.isDeathing) Move();
    }


    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, managerPoints.points[pos].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, managerPoints.points[pos].position) < 0.1)
        {
            if(pos == 6) Destroy(gameObject); 


            pos++;
        }
    }
}
