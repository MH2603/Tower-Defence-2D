using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPoints : MonoBehaviour
{
    public static ManagerPoints instance;

    public Transform[] points;

    private void Awake()
    {
        instance = this;
    }

    
}
