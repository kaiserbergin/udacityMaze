using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeGenerator : MonoBehaviour {
    public int sizeX;
    public int sizeZ;
    public MazeCell cellPrefab;

    private MazeCell[,] cells;
    private float scaleX;
    private float scaleZ;

    private List<MazeCellSet> cellSets;
    private List<MazeCellConnections> cellConnections;

    private void Awake()
    {
        cells = new MazeCell[sizeX, sizeZ];
        scaleX = cellPrefab.transform.localScale.x;
        scaleZ = cellPrefab.transform.localScale.z;
        cellSets = new List<MazeCellSet>();
        cellConnections = new List<MazeCellConnections>();
    }

    // Use this for initialization
    void Start () {        
		for(int x = 0; x < sizeX; x++)
        {
            for(int z = 0; z < sizeZ; z++)
            {
                CreateCell(x, z);
                MazeCellSet newCellSet = new MazeCellSet();               
                cellSets.Add(newCellSet);
                cellSets[cellSets.Count - 1].cells.Add(cells[x, z]);
            }
        }
	}
	
	public void CreateCell (int x, int z)
    {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[x, z] = newCell;
        newCell.name = "MazeCell(" + x + ", " + z + ")";
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(
            x * scaleX,
            0,
            z * scaleZ);
    }
}
