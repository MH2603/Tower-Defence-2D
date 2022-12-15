using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class player_HP : MonoBehaviour
{
    public Animator anima;

    public Text text_HP;

    public int HP;

    public bool invisible;


    private void Start()
    {
        UpdateHpUI();
    }

    public void ApplyDame(int value) // Get send messenger from bullet
    {

        if (HP <= 0) return; 

        HP -= value;

        if( value > 0)
        {
            anima.SetBool("hit", true);

            invisible = true;
            Invoke("SetInvisible", 0.6f);

            CameraAction.instance.ShakeCam();
        }
        
        UpdateHpUI();

        if( HP <= 0)
        {
            GameManager.instance.EndGame(); 
        }
    }

    void SetInvisible()
    {
        invisible = false;
    }


    void UpdateHpUI()
    {
        text_HP.text = "X " + HP.ToString();
    }
}
