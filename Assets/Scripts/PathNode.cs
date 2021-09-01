using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    public int x, y;
    private Grid<PathNode> grid;

    public int gCost, hCost, fCost;

    public bool isWalkable { get; set; }
    public PathNode cameFromNode;

    public PathNode(Grid<PathNode> grid, int x, int y)
    {
        this.x = x;
        this.y = y;
        this.grid = grid;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public override string ToString()
    {
        return x + "," + y;
    }
}
