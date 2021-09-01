

using UnityEngine;

public abstract class Level : MonoBehaviour
{
    public Grid<Tile> grid;

    /* 
     * SYNTAX:
     * 0 = Background
     * 1 = Path
     * 2 = Tower Base
     * 3 = Spawn
     * 4 = Base
     */
    public abstract int[,] Blueprint { get; }
    public abstract Tileset tileset { get; }

    private int width, height;

    // Grass prefabs
    public GameObject grass, grassSide, grassSides, grassCorner, grassSurround, grassPath, grassTowerBase, grassSpawn, grassBase;

    public Level()
    {
        width = Blueprint.GetLength(0);
        height = Blueprint.GetLength(1);
        grid = new Grid<Tile>(width, height, .32f, Vector3.zero, (Grid<Tile> grid, int x, int y) => new Tile(grid, x, y));
    }

    private void Start()
    {
        grass = Resources.Load("grass/Grass") as GameObject;
        grassSide = Resources.Load("grass/GrassSide") as GameObject;
        grassSides = Resources.Load("grass/GrassSides") as GameObject;
        grassCorner = Resources.Load("grass/GrassCorner") as GameObject;
        grassSurround = Resources.Load("grass/GrassSurround") as GameObject;
        grassPath = Resources.Load("grass/Path") as GameObject;
        grassTowerBase = Resources.Load("grass/GrassTowerBase") as GameObject;
        grassSpawn = Resources.Load("grass/Spawn") as GameObject;
        grassBase = Resources.Load("grass/Base") as GameObject;

        ConstructLevel();
        Debug.Log(Blueprint);
    }

    private void ConstructLevel()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Tile currentTile = grid.GetGridObject(x, y);
                int blueprintTile = Blueprint[x, y];

                if(blueprintTile == 1)
                {
                    // Path
                    currentTile.isPath = true;
                } else if(blueprintTile == 2)
                {
                    // Tower Base
                    currentTile.isTowerBase = true;
                } else if(blueprintTile == 3)
                {
                    // Spawn
                    currentTile.isSpawn = true;
                } else if(blueprintTile == 4)
                {
                    // Base
                    currentTile.isBase = true;
                } else
                {
                    // Background
                    int xAdjacency = 0, yAdjacency = 0;

                    // Check for path adjacency in x-direction
                    if(x + 1 < Blueprint.GetLength(0) && Blueprint[x + 1, y] == 1)
                    {
                        xAdjacency = 1;
                    }
                    if (x - 1 >= 0 && Blueprint[x - 1, y] == 1)
                    {
                        if (xAdjacency == 1)
                            xAdjacency = 2;
                        else
                            xAdjacency = -1;
                    }

                    // Check for path adjacency in y-direction
                    if (y + 1 < Blueprint.GetLength(1) && Blueprint[x, y + 1] == 1)
                    {
                        yAdjacency = 1;
                    }
                    if (y - 1 >= 0 && Blueprint[x, y - 1] == 1)
                    {
                        if (yAdjacency == 1)
                            yAdjacency = 2;
                        else
                            yAdjacency = -1;
                    }

                    // Set tile
                    if(xAdjacency != 0 || yAdjacency != 0)
                    {
                        currentTile.isAdjacentToPath = true;
                        currentTile.adjacentDirection = TranslateDirection(xAdjacency, yAdjacency);
                    }
                }

                Draw(currentTile);
            }
        }
    }

    private Direction TranslateDirection(int x, int y)
    {
        if(x == 2)
        {
            if (y == 1)
                return Direction.WNE;
            if (y == 0)
                return Direction.WE;
            if (y == -1)
                return Direction.ESW;
        }
        if(x == 1)
        {
            if (y == 2)
                return Direction.NES;
            if (y == 1)
                return Direction.NE;
            if (y == 0)
                return Direction.E;
            if (y == -1)
                return Direction.SE;
        }
        if (x == 0)
        {
            if (y == 2)
                return Direction.NS;
            if (y == 1)
                return Direction.N;
            if (y == -1)
                return Direction.S;
        }
        if (x == -1)
        {
            if (y == 2)
                return Direction.SWN;
            if (y == 1)
                return Direction.NW;
            if (y == 0)
                return Direction.W;
            if (y == -1)
                return Direction.SW;
        }
        return Direction.NONE;
    }

    public void Draw(Tile tile)
    {
        if (tileset == Tileset.GRASS)
        {
            GameObject t = null;
            if (tile.isPath)
            {
                t = Instantiate(grassPath) as GameObject;
                t.transform.position = grid.GetWorldPosition(tile.x, tile.y);
            } else if (tile.isTowerBase)
            {
                t = Instantiate(grassTowerBase) as GameObject;
                t.transform.position = grid.GetWorldPosition(tile.x, tile.y);
            } else if (tile.isSpawn)
            {
                t = Instantiate(grassSpawn) as GameObject;
                t.transform.position = grid.GetWorldPosition(tile.x, tile.y);
            } else if (tile.isBase)
            {
                t = Instantiate(grassBase) as GameObject;
                t.transform.position = grid.GetWorldPosition(tile.x, tile.y);
            } else if (tile.isAdjacentToPath)
            {
                switch (tile.adjacentDirection)
                {
                    case Direction.N:
                        t = Instantiate(grassSide) as GameObject;
                        t.transform.Rotate(0f, 0f, 90f, Space.Self);
                        break;
                    case Direction.NE:
                        t = Instantiate(grassCorner) as GameObject;
                        t.transform.Rotate(0f, 0f, 0f, Space.Self);
                        break;
                    case Direction.E:
                        t = Instantiate(grassSide) as GameObject;
                        break;
                    case Direction.SE:
                        t = Instantiate(grassCorner) as GameObject;
                        t.transform.Rotate(0f, 0f, 270f, Space.Self);
                        break;
                    case Direction.S:
                        t = Instantiate(grassSide) as GameObject;
                        t.transform.Rotate(0f, 0f, 270f, Space.Self);
                        break;
                    case Direction.SW:
                        t = Instantiate(grassCorner) as GameObject;
                        t.transform.Rotate(0f, 0f, 180f, Space.Self);
                        break;
                    case Direction.W:
                        t = Instantiate(grassSide) as GameObject;
                        t.transform.Rotate(0f, 0f, 180f, Space.Self);
                        break;
                    case Direction.NW:
                        t = Instantiate(grassCorner) as GameObject;
                        t.transform.Rotate(0f, 0f, 90f, Space.Self);
                        break;
                    case Direction.NS:
                        t = Instantiate(grassSides) as GameObject;
                        t.transform.Rotate(0f, 0f, 90f, Space.Self);
                        break;
                    case Direction.WE:
                        t = Instantiate(grassSides) as GameObject;
                        break;
                    case Direction.WNE:
                        t = Instantiate(grassSurround) as GameObject;
                        t.transform.Rotate(0f, 0f, 90f, Space.Self);
                        break;
                    case Direction.NES:
                        t = Instantiate(grassSurround) as GameObject;
                        break;
                    case Direction.ESW:
                        t = Instantiate(grassSurround) as GameObject;
                        t.transform.Rotate(0f, 0f, 270f, Space.Self);
                        break;
                    case Direction.SWN:
                        t = Instantiate(grassSurround) as GameObject;
                        t.transform.Rotate(0f, 0f, 180f, Space.Self);
                        break;
                }
                t.transform.position = grid.GetWorldPosition(tile.x, tile.y);
            }
            else
            {
                t = Instantiate(grass) as GameObject;
                t.transform.position = grid.GetWorldPosition(tile.x, tile.y);
            }
        }
    }
}
