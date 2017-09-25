using System;
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
    private float scaleY;

    private List<MazeCellSet> cellSets;
    private List<MazeCellConnections> cellConnections;
    private List<CoOrds> unvisitedCellCoOrds;

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
    }

    private void Awake()
    {
        scaleX = cellPrefab.transform.localScale.x;
        scaleZ = cellPrefab.transform.localScale.z;
        scaleY = cellWallPrefab.transform.localScale.y;

        cells = new MazeCell[sizeX, sizeZ];
        unvisitedCellCoOrds = new List<CoOrds>();

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
                cellSets.Add(new MazeCellSet());
                cellSets[cellSets.Count - 1].cells.Add(cells[x, z]);
                unvisitedCellCoOrds.Add(new CoOrds(x, z));
            }
        }
        for(int x = 0; x < sizeX + 1; x++)
        {
            for(int z = 0; z < sizeZ + 1; z++)
            {
                if (x < sizeX)
                {
                    MazeCellWall newCellWall = CreateHorizontalCellWall(x, z);
                }
                if (z < sizeZ)
                {
                    MazeCellWall mazeCellWall = CreateVerticalCellWall(x, z);
                }
                
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

    public MazeCellWall CreateHorizontalCellWall(int x, int z)
    {
        MazeCellWall newCellWall = Instantiate(cellWallPrefab) as MazeCellWall;
        newCellWall.name = "HorizontalCellWall(" + x + ", " + z + ")";
        newCellWall.transform.parent = transform;
        newCellWall.transform.localPosition = new Vector3(
            x * scaleX,
            scaleY / 2,
            z * scaleZ - scaleZ / 2);
        return newCellWall;
    }
    
    public MazeCellWall CreateVerticalCellWall(int x, int z)
    {
        MazeCellWall newCellWall = Instantiate(cellWallPrefab) as MazeCellWall;
        newCellWall.name = "VerticalCellWall(" + x + ", " + z + ")";
        newCellWall.transform.parent = transform;
        newCellWall.transform.localPosition = new Vector3(
            x * scaleX - scaleX / 2,
            scaleY / 2,
            z * scaleZ);
        newCellWall.transform.eulerAngles = new Vector3(0f, 90f, 0);
        return newCellWall;
    }

    public void CombineCellSets()
    {
        while(unvisitedCellCoOrds.Count > 0)
        {
            StartCoroutine(Delay());
            int cellIndex = UnityEngine.Random.Range(0, unvisitedCellCoOrds.Count);
            CoOrds cellCoOrds = unvisitedCellCoOrds[cellIndex];
            MazeCell visitedCell = cells[cellCoOrds.x, cellCoOrds.z];
            List<MazeCell> adjacentCells = new List<MazeCell>();
            bool setsMerged = false;

            if(cellCoOrds.x > 0)
            {
                adjacentCells.Add(cells[cellCoOrds.x - 1, cellCoOrds.z]);
            }
            if (cellCoOrds.x < sizeX - 1)
            {
                adjacentCells.Add(cells[cellCoOrds.x + 1, cellCoOrds.z]);
            }
            if (cellCoOrds.z > 0)
            {
                adjacentCells.Add(cells[cellCoOrds.x, cellCoOrds.z - 1]);
            }
            if (cellCoOrds.z < sizeZ - 1)
            {
                adjacentCells.Add(cells[cellCoOrds.x, cellCoOrds.z + 1]);
            }

            while(!setsMerged && adjacentCells.Count > 0)
            {
                int adjacentCellIndex = UnityEngine.Random.Range(0, adjacentCells.Count);

            }
        }        
    }
}
