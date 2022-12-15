using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class towerBlue : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletBlue;

    [SerializeField]
    private Bomb_Blue bombBlue;

    public float timeAttack = 4;

    public float timeDelay = 2f ;

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
        if (GameManager.instance.enemies.Count > 0 &&   ManagerSpawn.instance.isTurning )
        {
            Vector2 pos = GameManager.instance.enemies[UnityEngine.Random.Range(0, GameManager.instance.enemies.Count)].transform.position;

            //GameObject.Instantiate(bombBlue, pos, Quaternion.identity);

            GameObject newBullet = bulletBlue.Spawn(this.transform.position, Quaternion.identity);

            newBullet.transform.DOJump(pos, 3, 0, 2).SetEase(Ease.InOutQuad).OnComplete( () =>
            {
                newBullet.Recycle();
            });

            bombBlue.timeDelay = timeDelay; 
            bombBlue.Spawn(pos, Quaternion.identity);

        }

        Invoke("SpawBullet", timeAttack);
    
    }
}
