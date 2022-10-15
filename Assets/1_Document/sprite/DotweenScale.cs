using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DotweenScale : MonoBehaviour
{

    public float time = 1f;
    public Vector3 newScale;
    Vector3 startScale;

    public bool onEnable;
    public bool OnMouse;


    void Awake()
    {
        startScale = this.transform.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        this.transform.localScale = startScale;

        if (onEnable)
        {
            Scale(newScale, time);
        }

    }

    void OnMouseEnter()
    {
        if(OnMouse)
        {
            Scale(newScale,time);
        }
    }

    void OnMouseExit()
    {
        if (OnMouse)
        {
            Scale(startScale,time);
        }
    }

    public void Scale(Vector3 newScale, float time)
    {
        transform.DOScale(newScale, time).SetEase(Ease.InOutSine);
    }
}
