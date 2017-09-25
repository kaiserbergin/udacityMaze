using System;
using System.Collections.Generic;

public class MazeCellSet
{
    private Guid id;
    public List<MazeCell> cells;
    public MazeCellSet()
    {
        id = Guid.NewGuid();
        cells = new List<MazeCell>();
    }
    public Guid GetId()
    {
        return id;
    }
}
