
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{


    public int width,height;

    public GameObject tilePrefab;

    public Transform cam;

    [SerializeField] List<GameObject> listChild;

    [Header("Mode")]
    public modeInit mode;
    public enum modeInit { None,  createTile, switchTile }

    void Start()
    {
        switch (mode)
        {
            case modeInit.createTile:
                GenerateGrid();
                break;
            case modeInit.switchTile:
                SwitchGrid();
                break;
            
        }
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

    void SwitchGrid()
    {
        //for( int i=0; i < transform.childCount; i++)
        //{
        //    listChild.Add(transform.GetChild(i).gameObject);
        //}


        for(int i=0; i < listChild.Count; i++)
        {
            GameObject tile = Instantiate(tilePrefab);

            tile.transform.SetParent(this.transform);
            tile.name = listChild[i].name;
            tile.GetComponent<Tile>().layer = listChild[i].GetComponent<Tile>().layer;

            tile.transform.position = listChild[i].transform.position;

            Destroy(listChild[i].gameObject);
        }

        this.gameObject.SetActive(false);
    }




}
