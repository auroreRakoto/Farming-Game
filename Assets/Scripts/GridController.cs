using UnityEngine;

public class GridController : MonoBehaviour
{
	public static GridController instance;

	public void Awake()
	{
		instance = this;
	}

	public GrowBlock		baseGridBlock;
	private GrowBlock[,]	gridBlocks;
	public WorldData		worldData;
	public LayerMask		gridBlockersLayer;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		if (worldData == null)
		{
			Debug.LogError("WorldData is not assigned in GridController!");
			return;
		}
		GenerateGrid();
	}

	void GenerateGrid()
	{
		Vector3 startPosition = new Vector3((float)worldData.origin.x + .5f, (float)worldData.origin.y + .5f, 0);
		gridBlocks = new GrowBlock[worldData.width, worldData.height];


		for (int x = 0; x < worldData.width; x++)
		{	
			for (int y = 0; y < worldData.height; y++)
			{
				Vector3 spawnPosition = startPosition + new Vector3(x, y, 0);
				Vector2 boxSize = new Vector2(0.9f, 0.9f);
				
				Collider2D hit = Physics2D.OverlapBox(spawnPosition, boxSize, 0f, gridBlockersLayer);
				if (hit != null)
				{
					continue;
				}

				GrowBlock newBlock = Instantiate(baseGridBlock, spawnPosition, Quaternion.identity);
				newBlock.transform.SetParent(transform);
				gridBlocks[x, y] = newBlock;
				newBlock.SetCoordinates(spawnPosition.x, spawnPosition.y);
			}
		}
	}

	public GrowBlock GetBlockAt(float x, float y)
	{
		x = Mathf.RoundToInt(x);
		y = Mathf.RoundToInt(y);

		x -= worldData.origin.x;
		y -= worldData.origin.y;

		int intX = Mathf.RoundToInt(x);
		int intY = Mathf.RoundToInt(y);
		if (x < 0 || x >= worldData.width || y < 0 || y >= worldData.height)
			return null;

		
		return gridBlocks[intX, intY];
	}
}
