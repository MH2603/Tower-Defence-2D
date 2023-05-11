
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class player_HP : MonoBehaviour
{
    public Animator anima;
    public SpriteRenderer avatar;

    public Text text_HP;

    public int HP;
    public Color colorHit;

    public float timeInvisible = 0.6f;
    public bool invisible;
    [Header("Sound")]
    public AudioClip hitSound;

    private void Start()
    {
        UpdateHpUI();
    }

    public void ApplyDame(int value) // Get send messenger from bullet
    {

        if (HP <= 0) return; 

        HP -= value;
        SoundManager.Instance.ShowSound(hitSound, 0.8f);

        if( value > 0)
        {
            //anima.SetBool("hit", true);

            invisible = true;
            Invoke("SetInvisible", timeInvisible);
            StartCoroutine(EffectHit());

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

    IEnumerator EffectHit()
    {
        avatar.color = colorHit;
        yield return new WaitForSeconds(timeInvisible);
        avatar.color = Color.white;
    }

    
}
