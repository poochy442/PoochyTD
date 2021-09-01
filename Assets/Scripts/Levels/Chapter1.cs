using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1 : Level
{
    /* 
     * SYNTAX:
     * 0 = Background
     * 1 = Path
     * 2 = Tower Base
     * 3 = Spawn
     * 4 = Base
     */
    public override int[,] Blueprint
    {
        get { return new int[,]
            {
                {3, 1, 0, 0, 0, 1, 1, 1 },
                {0, 1, 2, 0, 2, 1, 2, 1 },
                {0, 1, 1, 1, 1, 1, 2, 1 },
                {0, 0, 2, 2, 0, 2, 0, 1 },
                {0, 0, 2, 1, 1, 1, 2, 1 },
                {0, 0, 2, 1, 2, 1, 2, 1 },
                {0, 0, 0, 1, 2, 1, 1, 1 },
                {0, 0, 0, 4, 0, 2, 0, 0 }
            };
        }
    }

    public override Tileset tileset
    {
        get { return Tileset.GRASS; }
    }

    public Chapter1() : base() { }
}
