using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraAction : MonoBehaviour
{
    public static CameraAction instance;

    [Header("Shake")]
    public float duration = 0.5f, strength = 0.5f;
    
    private void Awake()
    {
        instance = this;    
    }

   
    public void ShakeCam()
    {
        Vector3 pos =  this.transform.position;
        this.transform.DOShakePosition(duration, strength).OnComplete(() =>
        {
            this.transform.position = pos;
        });
    }
}
