using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool instance;

    List<GameObject> poolObjects = new List<GameObject>();
    public int amountToPool = 100;

    public GameObject prefab;

    void Awake()
    {
        if(instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.transform.SetParent(this.transform);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0;i < poolObjects.Count; i++)
        {
            if ( !poolObjects[i].activeInHierarchy) return poolObjects[i];
        }

        return null; 
    }
}
