using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SkillSpawn : BaseSkill
{

    public GameObject Seed;
    public GameObject EnemyF1;

    public float countSpawn;

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


        StartCoroutine(SpawnSeed());
    }

    IEnumerator SpawnSeed()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < countSpawn; i++)
        {
            Vector3 pos = this.transform.position;
            pos.x += Random.Range(-20f, 20f) * 0.05f;
            pos.y += Random.Range(-20f, 20f) * 0.05f;

            GameObject newSeed = Seed.Spawn(this.transform.position, Quaternion.identity);

            float force = Random.Range(0.1f, 0.5f);
            newSeed.transform.DOJump(pos, force, 0, 1f);

            StartCoroutine(SpawnF1(pos,newSeed)); // call spawn enemy
        }

        yield return null;  

    }

    IEnumerator SpawnF1(Vector3 pos,GameObject seed)
    {

        yield return new WaitForSeconds(1.5f);

        seed.Recycle();

        GameObject F1 = EnemyF1.Spawn(pos, Quaternion.identity);
        F1.GetComponent<Enemy_AI>().pos = AI.pos;

    }



   
}
