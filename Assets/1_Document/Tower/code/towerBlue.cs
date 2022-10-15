using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerBlue : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;


    public float timeAttack = 4;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawBullet", timeAttack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawBullet()
    {
        if (GameManager.instance.enemies.Count > 0 &&   GameManager.instance.isInTurn )
        {
            Vector3 pos = GameManager.instance.enemies[UnityEngine.Random.Range(0, GameManager.instance.enemies.Count)].transform.position;

            GameObject.Instantiate(bullet, pos, Quaternion.identity);

        }

        Invoke("SpawBullet", timeAttack);
    
    }
}
