using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniScene : MonoBehaviour
{

    public Animator ani;
    public GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void EndScene()
    {
        screen.SetActive(true);

        ani.SetBool("end", true);
    }
}
