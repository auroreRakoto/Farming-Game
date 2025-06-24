/*
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

		GenerateGround();
	}

	public void GenerateGround()
	{
		for (int x = 0; x < worldData.width; x++)
		{
			for (int y = 0; y < worldData.height; y++)
			{
				Vector3Int pos = new Vector3Int(x + worldData.origin.x, y + worldData.origin.y, 0);

				float xCoord = (float)x / worldData.groundNoiseScale;
				float yCoord = (float)y / worldData.groundNoiseScale;
				float noiseValue = Mathf.PerlinNoise(xCoord, yCoord);

				/*
				if (noiseValue > worldData.groundMinTreshold && noiseValue < worldData.groundMaxTreshold)
				{
					groundOverlayTilemap.SetTile(pos, bush);
				}
				*8/

				if (noiseValue > worldData.groundMaxTreshold)
				{
					groundOverlayTilemap.SetTile(pos, bush);
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
	*8/

	public void ClearMap()
	{

	}
}


*/
