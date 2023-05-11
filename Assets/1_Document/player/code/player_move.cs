using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{

    public Rigidbody2D rb;

    public Animator anima;

    public float speed;

    
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Flip();

        anima.SetFloat("run", movement.magnitude);

    }

    void FixedUpdate()
    {
        movement.Normalize();
        rb.velocity = movement * speed;
    }


    void Flip()
    {
        Vector3 tg = transform.GetChild(0).localScale;
        if (movement.x > 0) tg.x = 2;
        else if(movement.x < 0) tg.x = -2;

        transform.GetChild(0).localScale = tg;
    }
}
