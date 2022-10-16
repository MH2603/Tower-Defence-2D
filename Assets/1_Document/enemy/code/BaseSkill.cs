using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : MonoBehaviour
{



    [SerializeField]
    protected float TimeStart;

    [SerializeField]
    protected Vector2 timeCooldown;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Invoke("Skill", TimeStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected virtual void Skill()
    {
        
        Invoke("Skill",UnityEngine.Random.Range(timeCooldown.x,timeCooldown.y));
    }


}
