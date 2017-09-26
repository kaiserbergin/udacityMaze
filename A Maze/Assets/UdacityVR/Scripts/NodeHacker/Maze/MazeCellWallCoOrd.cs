using UnityEngine;
using System.Collections;

public struct MazeCellWallCoOrd
{

    public int x, z;
    public float rotation;
    public MazeCellWallCoOrd(int x, int z, float rotation = 0)
    {
        this.x = x;
        this.z = z;
        this.rotation = rotation;
    }
}
