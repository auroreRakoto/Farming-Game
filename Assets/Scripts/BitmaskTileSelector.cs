using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BitmaskTileSelector
{
	private readonly Dictionary<int, TileBase> _tilemap;

	public BitmaskTileSelector(Dictionary<int, TileBase> tilemap)
	{
		_tilemap = tilemap;
	}

	public TileBase GetTile(int bitmask)
	{
		if (_tilemap.TryGetValue(bitmask, out var tile))
			return (tile);
		Debug.Log("Tile " + bitmask + " Not Found");
		return (null);
	}

	bool IsWater(bool[,] map, int x, int y)
	{
		if (x >= 0 && y >= 0 && x < map.GetLength(0) && y < map.GetLength(1)) // Borders
			if (map[x, y]) // Case is water
				return true;
		return false;
	}

	public int GetWaterBitmask(bool[,] waterMap, int x, int y)
	{
		int mask = 0;

		if (IsWater(waterMap, x, y))
			return 255;
		if (IsWater(waterMap, x, y + 1))		// Top
			mask |= 1 << 0;
		if (IsWater(waterMap, x + 1, y + 1))	// TopRight
			mask |= 1 << 1;
		if (IsWater(waterMap, x + 1, y))		// Right
			mask |= 1 << 2;
		if (IsWater(waterMap, x + 1, y - 1))	// BottomRight
			mask |= 1 << 3;
		if (IsWater(waterMap, x, y - 1))		// Bottom
			mask |= 1 << 4;
		if (IsWater(waterMap, x - 1, y - 1))	// BottomLeft
			mask |= 1 << 5;
		if (IsWater(waterMap, x - 1, y))		// Left
			mask |= 1 << 6;
		if (IsWater(waterMap, x - 1, y + 1))	// TopLeft
			mask |= 1 << 7;

		if (IsWater(waterMap, x, y + 1) && !IsWater(waterMap, x + 1, y + 1) && !IsWater(waterMap, x + 1, y) && !IsWater(waterMap, x + 1, y - 1) && !IsWater(waterMap, x, y - 1) && !IsWater(waterMap, x - 1, y - 1) && !IsWater(waterMap, x - 1, y) && !IsWater(waterMap, x - 1, y + 1))
		{
			Debug.Log("Mask : " + mask);
			//Debug.Log("Top : " + IsWater(waterMap, x, y + 1));
			//Debug.Log("Top Right : " + IsWater(waterMap, x + 1, y + 1));
			//Debug.Log("Coord : " + x + ", " + y);
		}

		if (mask == 1 || mask == 3 || mask == 129 || mask == 131)	// TOP
			mask = 1;
		if (mask == 4 || mask == 6 || mask == 12 || mask == 14)		// RIGHT
			mask = 4;
		if (mask == 16 || mask == 24 || mask == 48 || mask == 56)	// DOWN
			mask = 16;
		if (mask == 64 || mask == 96 || mask == 192 || mask == 224)	// LEFT
			mask = 64;
		if (mask == 7 || mask == 15 || mask == 135 || mask == 143 || mask == 5 || mask == 13 || mask == 133 || mask == 141)	// TOP RIGHT
			mask = 7;
		if (mask == 28 || mask == 30 || mask == 60 || mask == 62 || mask == 20 || mask == 22 || mask == 52 || mask == 54)	// BOTTOM RIGHT
			mask = 28;
		if (mask == 112 || mask == 120 || mask == 240 || mask == 248 || mask == 80 || mask == 88 || mask == 208 || mask == 216)	// BOTTOM LEFT
			mask = 112;
		if (mask == 193 || mask == 195 || mask == 225 || mask == 227 || mask == 65 || mask == 67 || mask == 97 || mask == 99)	// TOP LEFT
			mask = 193;
		return mask;
	}
}
