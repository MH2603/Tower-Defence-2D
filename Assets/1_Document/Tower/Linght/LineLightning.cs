using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLightning : MonoBehaviour
{
    LineRenderer lineRenderer;

    

    [Header("AniThunder")]
    public Texture[] textures;

   
    int animationStep;
    float fbsCounter;
    public float fbs;

    [Header("Attack")]
    public float timeLife = 1f;
    public float timeCoolDown = 3f;
    public float Damge = 1f; 
    public int coutDamge = 3;


    void Awake() 
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    private void OnEnable()
    { 


        Invoke("ChoseEnemy", timeCoolDown);
    }

    // Update is called once per frame
    void Update()
    {
        fbsCounter += Time.deltaTime;

        if(fbsCounter >= 1 / fbs)
        {
            animationStep ++;

            if(animationStep == textures.Length) animationStep = 0;
           
            lineRenderer.material.SetTexture("_MainTex", textures[animationStep]);

            fbsCounter = 0f;
        }


        
    }


    public void Life()
    {
        
        lineRenderer.enabled = false;
        
    }


    void ChoseEnemy()
    {

        Invoke("ChoseEnemy", timeCoolDown);

       

        List<GameObject> ListEnemy = GameManager.instance.enemies;
        if (ListEnemy.Count == 0) return;


        // Sap xep tu be den lon
        for(int i = 0;i < ListEnemy.Count ; i++)
        {
            int num = i;
            
            for(int j = i+1;j < ListEnemy.Count; j++)
            {
                if(Vector3.Distance(this.transform.position,ListEnemy[j].transform.position) < Vector3.Distance(this.transform.position, ListEnemy[i].transform.position))
                {
                    num = j;
                }
            }

            if( num != i)
            {
                GameObject tg = ListEnemy[num];
                ListEnemy[num] = ListEnemy[i];
                ListEnemy[i] = tg; 
            }
        }

        if (ListEnemy.Count >= coutDamge ) lineRenderer.positionCount = coutDamge + 1;
        else lineRenderer.positionCount = ListEnemy.Count + 1;

        lineRenderer.SetPosition(0, this.transform.position);

        int num1 = ListEnemy.Count;
        for (int i = 1;i <= coutDamge && i <= num1 ; i++)
        {
            lineRenderer.SetPosition(i, ListEnemy[i - 1].transform.position);
            
            StartCoroutine(DoDamge(ListEnemy[i - 1]));
        }

        

        lineRenderer.enabled = true;
        Invoke("Life", timeLife);

        

    }

    IEnumerator DoDamge(GameObject enemy)
    {
        yield return new WaitForSeconds(0.3f);
        enemy.SendMessage("ApplyDame", Damge);
    }





}
