using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeGenerator : MonoBehaviour {
    public int sizeX;
    public int sizeZ;

    public MazeCell cellPrefab;
    private MazeCell[,] cells;

    public MazeCellWall cellWallPrefab;
    private MazeCellWall[,] cellWalls;

    private float scaleX;
    private float scaleZ;

    private List<MazeCellSet> cellSets;
    private List<MazeCellConnections> cellConnections;

    private void Awake()
    {
        scaleX = cellPrefab.transform.localScale.x;
        scaleZ = cellPrefab.transform.localScale.z;

        cells = new MazeCell[sizeX, sizeZ];
        cellSets = new List<MazeCellSet>();
        cellConnections = new List<MazeCellConnections>();

        cellWalls = new MazeCellWall[sizeX + 1, sizeZ + 1];
    }

    // Use this for initialization
    void Start () {        
		for(int x = 0; x < sizeX; x++)
        {
            for(int z = 0; z < sizeZ; z++)
            {
                MazeCell newCell = CreateCell(x, z);
                cells[x, z] = newCell;
                MazeCellSet newCellSet = new MazeCellSet();               
                cellSets.Add(newCellSet);
                cellSets[cellSets.Count - 1].cells.Add(cells[x, z]);
            }
        }
	}    
	
	public MazeCell CreateCell (int x, int z)
    {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;        
        newCell.name = "MazeCell(" + x + ", " + z + ")";
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(
            x * scaleX,
            0,
            z * scaleZ);
        return newCell;
    }
    
}
