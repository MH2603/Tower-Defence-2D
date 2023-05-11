using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEnemy : MonoBehaviour
{
    public List<GameObject> enemyChildren;
    public int[] enemyCout;

    
    bool first = true;

    // Start is called before the first frame update
    private void OnEnable()
    {
        first = true;
    }

    // Update is called once per frame
    void Update()
    {
        if( this.gameObject.GetComponent<BaseEnemy>().isDeathing && first) StartCoroutine(CallEnemies());
        if(this.gameObject.GetComponent<BaseEnemy>().isDeathing ) first = false;
    }


    IEnumerator CallEnemies()
    {
        yield return new WaitForSeconds(0.4f) ;

        for (int i = 0; i < enemyCout.Length; i++)
        {
            for (int j = 0; j < enemyCout[i]; j++)
            {
                StartCoroutine(SpawnEnemy(i));
            }
        }

        yield return null;
    }


    IEnumerator SpawnEnemy(int i )
    {
        Vector3 pos = this.transform.position;
        pos.y = pos.y + UnityEngine.Random.Range(-0.05f, 0.05f);
        GameObject enemy = GameObject.Instantiate(enemyChildren[i]);
        enemy.transform.position = pos;

        enemy.GetComponent<Enemy_AI>().idPos = this.gameObject.GetComponent<Enemy_AI>().idPos;

        yield return null;  
    }

}
