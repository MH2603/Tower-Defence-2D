using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onObject : MonoBehaviour
{
    public GameObject tutorial;

    private void OnMouseEnter()
    {
        tutorial.SetActive(true);
    }

    private void OnMouseExit()
    {
        tutorial.SetActive(false);
    }
}
