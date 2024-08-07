using UnityEngine;
using System.Collections;

public class WorldScroll : MonoBehaviour
{
    [System.Serializable]
    public struct Tile
    {
        public GameObject terrainTile;
        public Vector2Int positionOnGrid;
    }

    [SerializeField] Tile[] terrainTiles;
    [SerializeField] Transform playerTransform;
    private const float tileSize = 16f;
    private const int gridSize = 3;
    private const float timeToUpdateTiles = 1.2f;
    private Tile[,] tilesGrid;
    private Vector2Int lastPlayerPositionOnGrid;
    private Vector2Int currentPlayerPositionOnGrid;

    private void Awake()
    {
        InitializeGrid();
    }

    private void Start()
    {
        UpdateTiles();
        StartCoroutine(UpdateTilesCoroutine());
    }

    private void InitializeGrid()
    {
        tilesGrid = new Tile[gridSize, gridSize];
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                tilesGrid[i, j] = terrainTiles[i * gridSize + j];
                tilesGrid[i, j].terrainTile.transform.position = CalculateTilePosition(i, j);
            }
        }
    }

    private IEnumerator UpdateTilesCoroutine()
    {
        while (true)
        {
            UpdateTilesOnScreen();
            yield return new WaitForSeconds(timeToUpdateTiles);
        }
    }

    private void UpdateTilesOnScreen()
    {
        currentPlayerPositionOnGrid.x = Mathf.FloorToInt(playerTransform.position.x / tileSize);
        currentPlayerPositionOnGrid.y = Mathf.FloorToInt(playerTransform.position.y / tileSize);

        if (lastPlayerPositionOnGrid != currentPlayerPositionOnGrid)
        {
            lastPlayerPositionOnGrid = currentPlayerPositionOnGrid;
            UpdateTiles();
        }
    }

    private void UpdateTiles()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                int offsetX = currentPlayerPositionOnGrid.x - gridSize / 2 + i;
                int offsetY = currentPlayerPositionOnGrid.y - gridSize / 2 + j;
                int wrappedX = WrapIndex(offsetX, gridSize);
                int wrappedY = WrapIndex(offsetY, gridSize);

                Tile tile = tilesGrid[wrappedX, wrappedY];
                tile.terrainTile.transform.position = CalculateTilePosition(offsetX, offsetY);
            }
        }
    }

    private int WrapIndex(int index, int size)
    {
        return (index % size + size) % size;
    }

    private Vector3 CalculateTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, -1f);
    }
}
