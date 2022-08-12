using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_HP : MonoBehaviour
{

    public Animator anima;

    public Text text_HP;

    public int HP;

    public bool invisible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpDateUI();
    }


    void ApplyDame(int value) // Get send messenger from bullet
    {   
        HP -= value;
        anima.SetBool("hit", true);

        invisible = true;
        Invoke("SetInvisible", 0.6f);
       
    }

    void SetInvisible()
    {
        invisible = false;
    }


    void UpDateUI()
    {
        text_HP.text = "X " + HP.ToString();
    }
}
