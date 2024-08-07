using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePosition;

    private void Start()
    {

    }

    public void SetTilePosition(Vector2Int newPosition)
    {
        tilePosition = newPosition;
    }
}