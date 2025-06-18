using UnityEngine;
using UnityEngine.Tilemaps;

public class PondGenerator : MonoBehaviour
{
	public enum PondShape
	{
		Square,
		Circle,
		Random
	}

	public PondShape pondShape = PondShape.Circle;

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
		Debug.Log($"Generating Pond ({pondShape})...");

		if (tilemap == null)
		{
			Debug.LogWarning("Tilemap is not assigned!");
			return;
		}

		if (pondShape == PondShape.Square)
		{
			GenerateSquarePond(pondWidth, pondHeight, xOffset, yOffset);
		}
		else if (pondShape == PondShape.Circle)
		{
			GenerateCirclePond(pondWidth, pondHeight, xOffset, yOffset);
		}
	}


	public void GenerateSquarePond(int pondWidth, int pondHeight, int xOffset, int yOffset)
	{
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

	private void GenerateCirclePond(int pondWidth, int pondHeight, int xOffset, int yOffset)
	{
		float cx = pondWidth / 2f;
		float cy = pondHeight / 2f;
		float radius = Mathf.Min(pondWidth, pondHeight) / 2f;

		float borderThickness = 1f;

		for (int x = 0; x < pondWidth; x++)
		{
			for (int y = 0; y < pondHeight; y++)
			{
				float dx = x - cx + 0.5f;
				float dy = y - cy + 0.5f;
				float dist = Mathf.Sqrt(dx * dx + dy * dy);

				if (dist <= radius)
				{
					float distanceToEdge = radius - dist;

					TileBase tileToPlace = tileCenter;

					if (distanceToEdge <= borderThickness)
					{
						// On est sur le "bord" du cercle
						// On regarde l'angle pour savoir quel type de bord

						float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

						// On peut décider : "plage d'angle" → quelle tile

						if (angle >= -45f && angle < 45f)
							tileToPlace = tileRight; // droite
						else if (angle >= 45f && angle < 135f)
							tileToPlace = tileTop; // haut
						else if (angle >= -135f && angle < -45f)
							tileToPlace = tileBottom; // bas
						else
							tileToPlace = tileLeft; // gauche
					}

					// Sinon (on est "loin du bord") → tileCenter

					tilemap.SetTile(new Vector3Int(x + xOffset, y + yOffset, 0), tileToPlace);
				}
			}
		}
	}

}
