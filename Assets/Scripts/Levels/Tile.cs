using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tileset
{
    GRASS,
    STONE,
    FIRE
}

public enum Direction
{
    N, NE, E, SE, S, SW, W, NW, NS, WE, WNE, NES, ESW, SWN, NONE
}

public class Tile
{
    public int x, y;
    public bool isPath, isTowerBase, isAdjacentToPath, isSpawn, isBase;
    public Direction adjacentDirection;

    private Grid<Tile> grid;
    public Tileset tileset { get; set; }

    public Tile(Grid<Tile> grid, int x, int y)
    {
        this.x = x;
        this.y = y;
        this.grid = grid;

        isPath = false;
        isTowerBase = false;
        isAdjacentToPath = false;
        isSpawn = false;
        isBase = false;
    }

    
}