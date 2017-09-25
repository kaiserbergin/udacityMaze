using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

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
