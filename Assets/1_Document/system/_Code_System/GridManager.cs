using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{


    public int width,height;

    public GameObject tilePrefab;

    public Transform cam;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for(float x = 0 ;x < width; x++)
        {
            for(float y = 0;y < height; y++)
            {
                GameObject spawTile = Instantiate(tilePrefab, new Vector3(x - 7.5f, y - 1.5f) , Quaternion.identity );
                spawTile.name = "Tile" + x + y;
                spawTile.GetComponent<Tile>().layer = y;
                spawTile.transform.SetParent(this.transform);
               
            }
        }

        this.gameObject.SetActive(false);

        //cam.position = new Vector3((float)width/2 - 1,(float)height/2 - 1, -10);
    }



}
