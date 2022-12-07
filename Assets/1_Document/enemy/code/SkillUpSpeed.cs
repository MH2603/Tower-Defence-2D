using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUpSpeed : BaseSkill
{
    [SerializeField]
    private float timeUpSpeed = 2f;

    [SerializeField]
    private float ValuesSpeedUp = 2f;

    Animator ani;
    Enemy_AI AI;

    protected override void Start()
    {
        base.Start();

        ani = this.gameObject.GetComponent<Animator>();
        AI = this.gameObject.GetComponent<Enemy_AI>();


    }

    protected override void Skill()
    {
        base.Skill();

        ani.SetBool("OnSkill", true);

        float saveSpeed = AI.speed;
        AI.speed = ValuesSpeedUp;

        StartCoroutine(DownSpeed(saveSpeed));
       
    }

    IEnumerator DownSpeed(float saveSpeed)
    {
        yield return new WaitForSeconds( timeUpSpeed);
        AI.speed = saveSpeed;
    }

}
