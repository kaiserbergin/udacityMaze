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
    private List<MazeCellWall> unvisitedWalls;
    private List<CoOrds> itemCells;

    public WaypointNode wayPoint;
    public Key keyPrefab;
    public Door doorPrefab;
    public Coin coinPrefab;

    public float idealRoomRatio;

    private void Awake()
    {
        scaleX = cellPrefab.transform.localScale.x;
        scaleZ = cellPrefab.transform.localScale.z;
        scaleY = cellWallPrefab.transform.localScale.y;

        cells = new MazeCell[sizeX, sizeZ];

        cellSets = new List<MazeCellSet>();

        cellWalls = new List<MazeCellWall>();

        itemCells = new List<CoOrds>();

        unvisitedWalls = new List<MazeCellWall>();
    }

    // Use this for initialization
    void Start () {    
        //Create cells
		for(int x = 0; x < sizeX; x++)
        {
            for(int z = 0; z < sizeZ; z++)
            {
                MazeCell newCell = CreateCell(x, z);
                cells[x, z] = newCell;               
                cellSets.Add(new MazeCellSet());
                cellSets[cellSets.Count - 1].cells.Add(cells[x, z]);
            }
        }
        //Create walls
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
        unvisitedWalls.AddRange(cellWalls);
        CreateRooms();
        CombineCellSets();
        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                if(itemCells.FindIndex(cell => cell.x == x && cell.z == z) == -1)
                {
                    CreateWayPoint(x, z);
                }
            }
        }
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
        WaypointNode waypoint = Instantiate(wayPoint) as WaypointNode;
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
                    cellWalls.Remove(wallToDestroy);
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
                    cellWalls.Remove(wallToDestroy);
                }
            }
            unvisitedWalls.RemoveAt(unvisitedWallIndex);
        }
    }

    public void CreateRooms()
    {
        List<MazeCell> potentialRoomSeedCells = new List<MazeCell>();
        for(int x = 0; x < sizeX - 2; x++)
        {
            for(int z = 0; z < sizeZ - 2; z++)
            {
                potentialRoomSeedCells.Add(cells[x, z]);
            }
        }

        int totalCells = sizeX * sizeZ;
        int roomCount = (int)(totalCells * idealRoomRatio / 9 > 2 ? totalCells * idealRoomRatio / 9 : 2);

        for (int i = 0; i < roomCount; i++)
        {
            int cellIndex = UnityEngine.Random.Range(0, potentialRoomSeedCells.Count);
            CoOrds initialCoOrds = potentialRoomSeedCells[cellIndex].coOrds;
            float horizontalWallRotation = 0f;
            float verticalWallRotation = 90f;
            MazeCellSet initialCellSet = GetSetByCellCoordinates(initialCoOrds.x, initialCoOrds.z);

            int minX = initialCoOrds.x == 0 ? 0 : initialCoOrds.x - 1;
            int minZ = initialCoOrds.z == 0 ? 0 : initialCoOrds.z - 1;

            int maxX = initialCoOrds.x + 3 > sizeX - 1 ? sizeX - 1 : initialCoOrds.x + 3;
            int maxZ = initialCoOrds.z + 3 > sizeX - 1 ? sizeZ - 1 : initialCoOrds.z + 3;

            int roomMinX = initialCoOrds.x;
            int roomMinZ = initialCoOrds.z;

            int roomMaxX = initialCoOrds.x + 2;
            int roomMaxZ = initialCoOrds.z + 2;

            int seedMinX = initialCoOrds.x > 1 ? initialCoOrds.x - 2 : 0;
            int seedMinZ = initialCoOrds.z > 1 ? initialCoOrds.z - 2 : 0;

            for (int xPos = seedMinX; xPos < maxX + 1; xPos++)
            {
                for(int zPos = seedMinZ; zPos < maxZ + 1; zPos++)
                {
                    //Remove cell from available seed cells
                    int roomIndex = potentialRoomSeedCells.FindIndex(cell => cell.coOrds.x == xPos && cell.coOrds.z == zPos);
                    if (roomIndex != -1)
                    {
                        potentialRoomSeedCells.RemoveAt(roomIndex);
                    }                

                    //Merge cells into room cell set
                    if (xPos >= roomMinX && xPos <= roomMaxX && zPos >= roomMinZ && zPos <= roomMaxZ)
                    {
                        MazeCellSet currentCellSet = GetSetByCellCoordinates(xPos, zPos);
                        if (currentCellSet.GetId() != initialCellSet.GetId())
                        {
                            initialCellSet.cells.AddRange(currentCellSet.cells);
                            cellSets.Remove(currentCellSet);
                        }
                    }

                    //Remove horizontal walls from unvisited walls
                    if (xPos >= roomMinX && xPos <= roomMaxX && zPos > minZ)
                    {
                        int index = unvisitedWalls.FindIndex(wall => wall.mazeCellWallCoOrds.x == xPos && wall.mazeCellWallCoOrds.z == zPos && (int)wall.mazeCellWallCoOrds.rotation == (int)horizontalWallRotation);
                        if(index > -1)
                        {
                            unvisitedWalls.RemoveAt(index);
                        }
                    }

                    //Remove vertical walls from unvisited walls
                    if (zPos >= roomMinZ && zPos <= roomMaxZ && xPos > minX)
                    {
                        int index = unvisitedWalls.FindIndex(wall => wall.mazeCellWallCoOrds.x == xPos && wall.mazeCellWallCoOrds.z == zPos && wall.mazeCellWallCoOrds.rotation == verticalWallRotation);
                        if (index > -1)
                        {
                            unvisitedWalls.RemoveAt(index);
                        }
                    }

                    //Remove Vertical wall
                    if (xPos > roomMinX && xPos <= roomMaxX && zPos >= roomMinZ && zPos <= roomMaxZ)
                    {
                        MazeCellWall wallToDestroy = cellWalls.Find(wall => wall.mazeCellWallCoOrds.x == xPos && wall.mazeCellWallCoOrds.z == zPos && wall.mazeCellWallCoOrds.rotation == verticalWallRotation);
                        if(wallToDestroy != null)
                        {
                            Destroy(wallToDestroy.gameObject);
                            cellWalls.Remove(wallToDestroy);
                        }
                    }

                    //Remove horizontal wall
                    if(zPos > roomMinZ && zPos <= roomMaxZ && xPos >= roomMinX && xPos <= roomMaxX)
                    {
                        MazeCellWall wallToDestroy = cellWalls.Find(wall => wall.mazeCellWallCoOrds.x == xPos && wall.mazeCellWallCoOrds.z == zPos && wall.mazeCellWallCoOrds.rotation == horizontalWallRotation);
                        if (wallToDestroy != null)
                        {
                            Destroy(wallToDestroy.gameObject);
                            cellWalls.Remove(wallToDestroy);
                        }
                    }

                    //Add item cell
                    if(xPos == initialCoOrds.x + 1 && zPos == initialCoOrds.z + 1)
                    {
                        itemCells.Add(new CoOrds(xPos, zPos));
                        if(i == 0)
                        {
                            Door door = Instantiate(doorPrefab) as Door;
                            door.name = "Key(" + xPos + ", " + zPos + ")";
                            door.transform.parent = transform;
                            door.transform.localPosition = new Vector3(
                                xPos * scaleX,
                                scaleY / 2,
                                zPos * scaleZ);
                        }
                        else if(i == 1)
                        {
                            Key key = Instantiate(keyPrefab) as Key;
                            key.name = "Key(" + xPos + ", " + zPos + ")";
                            key.transform.parent = transform;
                            key.transform.localPosition = new Vector3(
                                xPos * scaleX,
                                scaleY / 2,
                                zPos * scaleZ);
                        }
                        else
                        {
                            Coin coin = Instantiate(coinPrefab) as Coin;
                            coin.name = "Key(" + xPos + ", " + zPos + ")";
                            coin.transform.parent = transform;
                            coin.transform.localPosition = new Vector3(
                                xPos * scaleX,
                                scaleY / 2,
                                zPos * scaleZ);
                        }
                    }
                }
            }

            int roomOpenings = UnityEngine.Random.Range(1, 4);
            List<MazeCellWall> boundaryWalls = new List<MazeCellWall>();
            for(int x = roomMinX; x < maxX + 1; x++)
            {
                for(int z = roomMinZ; z < maxZ + 1; z++)
                {
                    //Add vertical walls
                    if(x != 0 && x != sizeX - 1 && (x == roomMinX || x == maxX) && z < maxZ)
                    {
                        boundaryWalls.Add(cellWalls.Find(wall => wall.mazeCellWallCoOrds.x == x && wall.mazeCellWallCoOrds.z == z && wall.mazeCellWallCoOrds.rotation == verticalWallRotation));
                    }
                    //Add horizontal walls
                    if(z != 0 && z != sizeZ - 1 && (z == roomMinZ || z == maxZ) && x < maxX)
                    {
                        boundaryWalls.Add(cellWalls.Find(wall => wall.mazeCellWallCoOrds.x == x && wall.mazeCellWallCoOrds.z == z && wall.mazeCellWallCoOrds.rotation == horizontalWallRotation));
                    }
                }
            }
            for(int j = 0; j < roomOpenings; j++)
            {
                int wallIndex = UnityEngine.Random.Range(0, boundaryWalls.Count);
                MazeCellWall boundaryWall = boundaryWalls[wallIndex];
                if(boundaryWall != null)
                {
                    MazeCellWall cellWall = cellWalls.Find(wall =>
                        wall.mazeCellWallCoOrds.x == boundaryWall.mazeCellWallCoOrds.x &&
                        wall.mazeCellWallCoOrds.z == boundaryWall.mazeCellWallCoOrds.z &&
                        (int)wall.mazeCellWallCoOrds.rotation == (int)boundaryWall.mazeCellWallCoOrds.rotation);

                    if(cellWall)
                    {
                        int x = cellWall.mazeCellWallCoOrds.x;
                        int z = cellWall.mazeCellWallCoOrds.z;
                        float wallRotation = cellWall.mazeCellWallCoOrds.rotation;
                        
                        //Horizontal Walls
                        if (wallRotation == 0 && z != 0 && z != sizeZ)
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
                                cellWalls.Remove(wallToDestroy);
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
                                cellWalls.Remove(wallToDestroy);
                            }
                        }
                    }
                    boundaryWalls.RemoveAt(wallIndex);
                }
            }
        }
    }

    public MazeCellSet GetSetByCellCoordinates(int x, int z)
    {
        foreach (var set in cellSets)
        {
            foreach (var cell in set.cells)
            {
                if (cell.coOrds.x == x && cell.coOrds.z == z)
                {
                    return set;
                }
            }
        }
        return null;
    }    
}
