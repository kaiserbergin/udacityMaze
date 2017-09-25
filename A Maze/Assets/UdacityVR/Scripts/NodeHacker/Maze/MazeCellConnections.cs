using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MazeCellConnections
{
    public MazeCell cell;
    public List<MazeCell> connectedCells;

    public MazeCellConnections()
    {
        cell = new MazeCell();
        connectedCells = new List<MazeCell>();
    }
    public MazeCellConnections(MazeCell cell)
    {
        this.cell = cell;
        connectedCells = new List<MazeCell>();
    }
    public MazeCellConnections(MazeCell cell, List<MazeCell> connectedCells)
    {
        this.cell = cell;
        this.connectedCells = connectedCells;
    }
}
