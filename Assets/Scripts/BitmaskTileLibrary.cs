using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;


[CreateAssetMenu(menuName = "Tiles/Bitmask Tile Library")]
public class BitmaskTileLibrary : ScriptableObject
{
	[System.Serializable]
	public struct BitmaskEntry
	{
		public int bitmask;
		public TileBase tile;
	}

	public BitmaskEntry[] entries;

	public Dictionary<int, TileBase> ToDictionary()
	{
		var dict = new Dictionary<int, TileBase>();
		foreach (var entry in entries)
		{
			dict[entry.bitmask] = entry.tile;
		}
		return dict;
	}
}
