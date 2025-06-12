using UnityEngine;
using UnityEngine.Tilemaps;

public class PondGenerator : MonoBehaviour
{
    public Tilemap tilemap;

    public TileBase tileCenter;
    public TileBase tileTop;
    public TileBase tileBottom;
    public TileBase tileLeft;
    public TileBase tileRight;
    public TileBase tileOuterTopLeft;
    public TileBase tileOuterTopRight;
    public TileBase tileOuterBottomLeft;
    public TileBase tileOuterBottomRight;
    public TileBase tileInnerTopLeft;
    public TileBase tileInnerTopRight;
    public TileBase tileInnerBottomLeft;
    public TileBase tileInnerBottomRight;

    // Temporary Values
    //public int pondWidth = 5;
    //public int pondHeight = 5;

    public void GeneratePond(int pondWidth, int pondHeight, int xOffset, int yOffset)
    {
        Debug.Log("Generating Pond...");

        if (tilemap == null)
        {
            Debug.LogWarning("Tilemap is not assigned!");
            return;
        }

        for (int x = 0; x < pondWidth; x++)
        {
            for (int y = 0; y < pondHeight; y++)
            {
                TileBase tileToPlace = tileCenter;
                // Corners
                if (x == 0 && y == pondHeight - 1)
                    tileToPlace = tileOuterTopLeft;
                else if (x == pondWidth - 1 && y == pondHeight - 1)
                    tileToPlace = tileOuterTopRight;
                else if (x == 0 && y == 0)
                    tileToPlace = tileOuterBottomLeft;
                else if (x == pondWidth - 1 && y == 0)
                    tileToPlace = tileOuterBottomRight;

                // Borders
                else if (y == pondHeight - 1)
                    tileToPlace = tileTop;
                else if (y == 0)
                    tileToPlace = tileBottom;
                else if (x == 0)
                    tileToPlace = tileLeft;
                else if (x == pondWidth - 1)
                    tileToPlace = tileRight;

                // Center (default is tileCenter, so nothing to do)

                tilemap.SetTile(new Vector3Int(x + xOffset, y + yOffset, 0), tileToPlace);
            }
        }
    }
}
