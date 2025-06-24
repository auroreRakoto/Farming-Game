using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
	public int seed = 12345;
	private System.Random rng;
	
	public Tilemap groundTilemap;
	public Tilemap		groundOverlayTilemap;
	public TileBase		green;
	public TileBase		bush;
	public WorldData	worldData;
	public WorldTiles	worldTiles;

	public void GenerateMap()
	{
		rng = new System.Random(seed);
		Debug.Log("Map Generated !");
		groundTilemap.ClearAllTiles();
		groundOverlayTilemap.ClearAllTiles();

		for (int x = 0; x < worldData.width; x++)
		{
			for (int y = 0; y < worldData.height; y++)
			{
				groundTilemap.SetTile(new Vector3Int(x + worldData.origin.x, y + worldData.origin.y, 0), green);
			}
		}

		GeneratePond();
	}

	private void GeneratePond()
	{
		bool[,] waterMap = new bool[worldData.width, worldData.height];

		// Première passe : placer les tiles d'eau au centre
		for (int x = 0; x < worldData.width; x++)
		{
			for (int y = 0; y < worldData.height; y++)
			{
				float xCoord = (x + worldData.origin.x + seed) / worldData.groundNoiseScale;
				float yCoord = (y + worldData.origin.y + seed) / worldData.groundNoiseScale;
				float noiseValue = Mathf.PerlinNoise(xCoord, yCoord);

				if (noiseValue < worldData.waterMinTreshold)
				{
					waterMap[x, y] = true;

					Vector3Int pos = new Vector3Int(x + worldData.origin.x, y + worldData.origin.y, 0);
					groundOverlayTilemap.SetTile(pos, worldTiles.waterCenter);
				}
			}
		}
		PondBorders(waterMap);
	}

	private void PondBorders(bool[,] waterMap)
	{ 
		// Deuxième passe : poser les bords
		for (int x = 0; x < worldData.width; x++)
		{
			for (int y = 0; y < worldData.height; y++)
			{
				if (!waterMap[x, y])
					continue;

				// Directions [dx, dy, tile]
				(Vector2Int offset, TileBase tile)[] directions = new (Vector2Int, TileBase)[]
				{
					(new Vector2Int(0, 1), worldTiles.waterTop),
					(new Vector2Int(0, -1), worldTiles.waterBottom),
					(new Vector2Int(-1, 0), worldTiles.waterLeft),
					(new Vector2Int(1, 0), worldTiles.waterRight),
					(new Vector2Int(-1, 1), worldTiles.waterTopLeft),
					(new Vector2Int(1, 1), worldTiles.waterTopRight),
					(new Vector2Int(-1, -1), worldTiles.waterBottomLeft),
					(new Vector2Int(1, -1), worldTiles.waterBottomRight),
				};

				foreach (var (offset, tile) in directions)
				{
					int nx = x + offset.x;
					int ny = y + offset.y;

					if (nx >= 0 && ny >= 0 && nx < worldData.width && ny < worldData.height && !waterMap[nx, ny])
					{
						Vector3Int borderPos = new Vector3Int(nx + worldData.origin.x, ny + worldData.origin.y, 0);
						if (groundOverlayTilemap.GetTile(borderPos) == null)
						{
							groundOverlayTilemap.SetTile(borderPos, tile);
						}
					}
				}
			}
		}
	}

	int GetWaterBitmask(bool[,] waterMap, int x, int y)
	{
		int mask = 0;

		if (IsWater(waterMap, x, y + 1)) mask |= 1 << 0;      // Top
		if (IsWater(waterMap, x + 1, y + 1)) mask |= 1 << 1;  // TopRight
		if (IsWater(waterMap, x + 1, y)) mask |= 1 << 2;      // Right
		if (IsWater(waterMap, x + 1, y - 1)) mask |= 1 << 3;  // BottomRight
		if (IsWater(waterMap, x, y - 1)) mask |= 1 << 4;      // Bottom
		if (IsWater(waterMap, x - 1, y - 1)) mask |= 1 << 5;  // BottomLeft
		if (IsWater(waterMap, x - 1, y)) mask |= 1 << 6;      // Left
		if (IsWater(waterMap, x - 1, y + 1)) mask |= 1 << 7;  // TopLeft

		return mask;
	}
	bool IsWater(bool[,] map, int x, int y)
	{
		if (x >= 0 && y >= 0 && x < map.GetLength(0) && y < map.GetLength(1)) // Borders
			if (map[x, y]) // Case is water
				return true;
		return false;
	}


	/* Template ft
	public void GenerateGround()
	{
		for (int x = 0; x < worldData.width; x++)
		{
			for (int y = 0; y < worldData.height; y++)
			{ 
				
			}
		}
	}
	*/

	public void ClearMap()
	{

	}
}
