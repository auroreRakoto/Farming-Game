using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
	//public int seed = 1;
	private System.Random		rng;
	
	public Tilemap				groundTilemap;
	public Tilemap				groundOverlayTilemap;
	public Tilemap				hardObjectsTilemap;
	public Tilemap				hardObjectsOverlayTilemap;
	public TileBase				green;
	public TileBase				bush;
	public WorldData			worldData;
	public WorldTiles			worldTiles;
	public BitmaskTileLibrary	waterTileLibrary;
	private BitmaskTileSelector	tileSelector;	

	public void GenerateMap(int seed)
	{
		rng = new System.Random(seed);
		Debug.Log("Map Generated !");
		ClearMap();

		for (int x = 0; x < worldData.width; x++)
		{
			for (int y = 0; y < worldData.height; y++)
			{
				groundTilemap.SetTile(new Vector3Int(x + worldData.origin.x, y + worldData.origin.y, 0), green);
			}
		}

		GeneratePond(seed);
	}

	private void GeneratePond(int seed)
	{
		tileSelector = new BitmaskTileSelector(waterTileLibrary.ToDictionary());

		bool[,] waterMap = new bool[worldData.width, worldData.height];

		// Première passe : verifier si les tiles sont de l'eau
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
				}
			}
		}
		PondBorders(waterMap);
	}

	private void PondBorders(bool[,] waterMap)
	{ 
		// Deuxième passe : setup les bords avec les bitmask
		for (int x = 0; x < worldData.width; x++)
		{
			for (int y = 0; y < worldData.height; y++)
			{
				//if (!waterMap[x, y])
				//	continue;

				int mask = tileSelector.GetWaterBitmask(waterMap, x, y);
				TileBase tile = tileSelector.GetTile(mask);
				

				if (tile != null)
				{
					Vector3Int pos = new Vector3Int(x + worldData.origin.x, y + worldData.origin.y, 0);
					hardObjectsTilemap.SetTile(pos, tile);
				}
			}
		}
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
		groundTilemap.ClearAllTiles();
		groundOverlayTilemap.ClearAllTiles();
		hardObjectsTilemap.ClearAllTiles();
		hardObjectsOverlayTilemap.ClearAllTiles();
	}
}
