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
    public TileBase				bush2;
    public TileBase				bush3;
	public WorldData			worldData;
	public WorldTiles			worldTiles;
	public BitmaskTileLibrary	waterTileLibrary;
	private BitmaskTileSelector	tileSelector;

    public void Start()
    {
        GenerateMapBorders();
    }

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

        tileSelector = new BitmaskTileSelector(waterTileLibrary.ToDictionary());

		GeneratePond(seed);
        //GenerateMapBorders();
	}

	private void GeneratePond(int seed)
	{
		bool[,] waterMap = new bool[worldData.width, worldData.height];
        bool[,] grass1Map = new bool[worldData.width, worldData.height];

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
				} else //if (noiseValue < 0.6 && noiseValue > 0.5)
                {
                    //grass1Map[x, y] = true;
                    float r = UnityEngine.Random.value;
                    if (r < 0.1)
                    {
                        Vector3Int pos = new Vector3Int(x + worldData.origin.x, y + worldData.origin.y, 0);
                        groundOverlayTilemap.SetTile(pos, bush);
                    }
                    r = UnityEngine.Random.value;
                    if (r < 0.06)
                    {
                        Vector3Int pos = new Vector3Int(x + worldData.origin.x, y + worldData.origin.y, 0);
                        groundOverlayTilemap.SetTile(pos, bush2);
                    }
                    r = UnityEngine.Random.value;
                    if (r < 0.03)
                    {
                        Vector3Int pos = new Vector3Int(x + worldData.origin.x, y + worldData.origin.y, 0);
                        groundOverlayTilemap.SetTile(pos, bush3);
                    }
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

    private void GenerateMapBorders()
    {
        float left = worldData.origin.x - 0.5f;
        float right = worldData.origin.x + worldData.width + 0.5f;
        float bottom = worldData.origin.y - 0.5f;
        float top = worldData.origin.y + worldData.height + 0.5f;

        GameObject leftWall = new GameObject("InvisibleLeftWall");
        leftWall.transform.position = new Vector2(left, ((top - bottom) / 2) + bottom);
        leftWall.transform.localScale = new Vector2(1, top - bottom);
        BorderWall(leftWall);

        GameObject rightWall = new GameObject("InvisibleRightWall");
        rightWall.transform.position = new Vector2(right, ((top - bottom) / 2) + bottom);
        rightWall.transform.localScale = new Vector2(1, top - bottom);
        BorderWall(rightWall);

        GameObject topWall = new GameObject("InvisibleTopWall");
        topWall.transform.position = new Vector2(((right - left) / 2) + left, top);
        topWall.transform.localScale = new Vector2(right - left, 1);
        BorderWall(topWall);

        GameObject bottomWall = new GameObject("InvisibleBottomWall");
        bottomWall.transform.position = new Vector2(((right - left) / 2) + left, bottom);
        bottomWall.transform.localScale = new Vector2(right - left, 1);
        BorderWall(bottomWall);
    }

    private void BorderWall(GameObject wall)
    {
        SpriteRenderer wallSr = wall.AddComponent<SpriteRenderer>();
        wallSr.color = new Color(0, 120f, 0, 0.5f);
        Rigidbody2D wallRb = wall.AddComponent<Rigidbody2D>();
        wallRb.bodyType = RigidbodyType2D.Static;
        BoxCollider2D wallCol = wall.AddComponent<BoxCollider2D>();
        wallCol.size = wall.transform.localScale;
        wall.transform.SetParent(transform);
    }




	public void ClearMap()
	{
		groundTilemap.ClearAllTiles();
		groundOverlayTilemap.ClearAllTiles();
		hardObjectsTilemap.ClearAllTiles();
		hardObjectsOverlayTilemap.ClearAllTiles();
	}
}
