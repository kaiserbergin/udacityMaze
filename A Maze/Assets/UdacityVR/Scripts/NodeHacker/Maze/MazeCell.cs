﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MazeCell : MonoBehaviour {
    private Guid id;
    public CoOrds coOrds;
    public MazeCell()
    {
        id = Guid.NewGuid();
    }
    public Guid GetId()
    {
        return id;
    }

}
