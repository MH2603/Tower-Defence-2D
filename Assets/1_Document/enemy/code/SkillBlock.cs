using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBlock : BaseSkill
{
    [SerializeField]
    private float timeBlock = 1.5f;

    Animator ani;
    Enemy_AI AI;

    Vector2 V;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        ani = this.gameObject.GetComponent<Animator>();
        AI  = this.gameObject.GetComponent<Enemy_AI>();
       

    }

    protected override void Skill()
    {
        base.Skill();

        ani.SetBool("OnSkill", true);
        AI.Stop = true;
       
        this.gameObject.tag = "blockBullet";
        Invoke("CallTag", timeBlock);
    }

    void CallTag()
    {
        this.gameObject.tag = "enemy";
        AI.Stop = false;
 
    }
}
