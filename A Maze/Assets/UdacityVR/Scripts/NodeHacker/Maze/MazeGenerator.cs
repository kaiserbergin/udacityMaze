using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeGenerator : MonoBehaviour {
    public int sizeX;
    public int sizeZ;
    public MazeCell cellPrefab;

    private MazeCell[,] cells;
    private List<List<MazeCell>> cellSets;
    private float scaleX;
    private float scaleZ;

    private void Awake()
    {
        cells = new MazeCell[sizeX, sizeZ];
        scaleX = cellPrefab.transform.localScale.x;
        scaleZ = cellPrefab.transform.localScale.z;
        Debug.Log("set values in Awake");
        Debug.Log("cells.Length: " + cells.Length);
        Debug.Log("scaleX: " + scaleX);
        Debug.Log("scaleZ: " + scaleZ);
    }

    // Use this for initialization
    void Start () {        
		for(int x = 0; x < sizeX; x++)
        {
            for(int z = 0; z < sizeZ; z++)
            {
                CreateCell(x, z);
            }
        }
	}
	
	public void CreateCell (int x, int z)
    {
        Debug.Log("Creating Cell at x:" + x + " and z: " + z);
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[x, z] = newCell;
        newCell.name = "MazeCell(" + x + ", " + z + ")";
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(
            x - sizeX * scaleX + scaleX / 2,
            0,
            z - sizeZ * scaleZ + scaleZ / 2);
        Debug.Log("newCell.name: " + newCell.name);
        Debug.Log("newCell.transform.parent: " + newCell.transform.parent);
        Debug.Log("newCell.transform.localPosition: " + newCell.transform.localPosition);
    }
}
