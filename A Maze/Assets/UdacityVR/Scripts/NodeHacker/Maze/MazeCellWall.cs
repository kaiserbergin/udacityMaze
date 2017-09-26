﻿using System;
using UnityEngine;
using System.Collections;

public class MazeCellWall : MonoBehaviour
{
    private Guid id;
    public MazeCellWallCoOrd mazeCellWallCoOrds;
    public MazeCellWall()
    {
        id = Guid.NewGuid();
    }
    public Guid GetId()
    {
        return id;
    }
}
