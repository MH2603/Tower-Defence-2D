using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInvisible : BaseSkill
{
    [SerializeField]
    private float timeInvisible = 1f;
    
    
    protected Animator ani;

    private Collider2D coll;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        ani  = this.gameObject.GetComponent<Animator>();
        coll = this.gameObject.GetComponent<Collider2D>();
    }

    protected override void Skill()
    {
        base.Skill();

        ani.SetBool("OnSkill", true);

        coll.enabled = false;
        Invoke("OnColl", timeInvisible);

    }


    private void OnColl()
    {
        coll.enabled = true;
    }
}
