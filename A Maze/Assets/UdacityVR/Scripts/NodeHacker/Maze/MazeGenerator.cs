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
    private List<MazeCellWall> cellWalls;

    private float scaleX;
    private float scaleZ;
    private float scaleY;

    private List<MazeCellSet> cellSets;

    public Waypoint wayPoint;

    private void Awake()
    {
        scaleX = cellPrefab.transform.localScale.x;
        scaleZ = cellPrefab.transform.localScale.z;
        scaleY = cellWallPrefab.transform.localScale.y;

        cells = new MazeCell[sizeX, sizeZ];

        cellSets = new List<MazeCellSet>();

        cellWalls = new List<MazeCellWall>();
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

                CreateWayPoint(x, z);
            }
        }
        for(int x = 0; x < sizeX + 1; x++)
        {
            for(int z = 0; z < sizeZ + 1; z++)
            {
                if (x < sizeX)
                {
                    MazeCellWall horizontalWall = CreateHorizontalCellWall(x, z);
                    cellWalls.Add(horizontalWall);
                }
                if (z < sizeZ)
                {
                    MazeCellWall verticalCellWall = CreateVerticalCellWall(x, z);
                    cellWalls.Add(verticalCellWall);
                }
                
            }
        }
        CombineCellSets();

    }    
	
	public MazeCell CreateCell (int x, int z)
    {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        newCell.name = "MazeCell(" + x + ", " + z + ")";
        newCell.coOrds = new CoOrds(x, z);
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(
            x * scaleX,
            0,
            z * scaleZ);
        return newCell;
    }

    public void CreateWayPoint(int x, int z)
    {
        //I don't like these waypoints...
        Waypoint waypoint = Instantiate(wayPoint) as Waypoint;
        waypoint.name = "WayPoint(" + x + ", " + z + ")";
        waypoint.transform.parent = transform;
        waypoint.transform.localPosition = new Vector3(
            x * scaleX,
            scaleY / 2,
            z * scaleZ);
    }

    public MazeCellWall CreateHorizontalCellWall(int x, int z)
    {
        MazeCellWall newCellWall = Instantiate(cellWallPrefab) as MazeCellWall;
        newCellWall.mazeCellWallCoOrds = new MazeCellWallCoOrd(x, z, 0);
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
        newCellWall.mazeCellWallCoOrds = new MazeCellWallCoOrd(x, z, 90f);
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
        List<MazeCellWall> unvisitedWalls = new List<MazeCellWall>();
        unvisitedWalls.AddRange(cellWalls);
        while(unvisitedWalls.Count > 0)
        {
            int unvisitedWallIndex = UnityEngine.Random.Range(0, unvisitedWalls.Count);
            int x, z;
            float wallRotation;
            x = unvisitedWalls[unvisitedWallIndex].mazeCellWallCoOrds.x;
            z = unvisitedWalls[unvisitedWallIndex].mazeCellWallCoOrds.z;
            wallRotation = unvisitedWalls[unvisitedWallIndex].mazeCellWallCoOrds.rotation;

            //Horizontal Walls
            if (wallRotation == 0 && z != 0 && z != sizeZ)
            {
                MazeCellSet firstSet = null;
                MazeCellSet secondSet = null;
                foreach(var set in cellSets)
                {
                    foreach(var cell in set.cells)
                    {
                        if(cell.coOrds.x == x && cell.coOrds.z == z)
                        {
                            firstSet = set;
                        }
                        else if (cell.coOrds.x == x && cell.coOrds.z == z - 1)
                        {
                            secondSet = set;
                        }
                        if (firstSet != null && secondSet != null) break;
                    }
                }
                if (firstSet.GetId() != secondSet.GetId())
                {
                    firstSet.cells.AddRange(secondSet.cells);
                    cellSets.Remove(secondSet);
                    MazeCellWall wallToDestroy = cellWalls.Find(wall => wall.mazeCellWallCoOrds.x == x && wall.mazeCellWallCoOrds.z == z && wall.mazeCellWallCoOrds.rotation == wallRotation);
                    Destroy(wallToDestroy.gameObject);
                }
            }
            //Vertical Walls
            if (wallRotation == 90f && x != 0 && x != sizeX)
            {
                MazeCellSet firstSet = null;
                MazeCellSet secondSet = null;
                foreach (var set in cellSets)
                {
                    foreach (var cell in set.cells)
                    {
                        if (cell.coOrds.x == x && cell.coOrds.z == z)
                        {
                            firstSet = set;
                        }
                        else if (cell.coOrds.x == x - 1 && cell.coOrds.z == z)
                        {
                            secondSet = set;
                        }
                        if (firstSet != null && secondSet != null) break;
                    }
                }
                if (firstSet.GetId() != secondSet.GetId())
                {
                    firstSet.cells.AddRange(secondSet.cells);
                    cellSets.Remove(secondSet);
                    MazeCellWall wallToDestroy = cellWalls.Find(wall => wall.mazeCellWallCoOrds.x == x && wall.mazeCellWallCoOrds.z == z && wall.mazeCellWallCoOrds.rotation == wallRotation);
                    Destroy(wallToDestroy.gameObject);
                }
            }
            unvisitedWalls.RemoveAt(unvisitedWallIndex);
        }
    }
}
