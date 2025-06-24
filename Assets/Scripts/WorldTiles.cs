using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewWorldTiles", menuName = "World/WorldTiles")]
public class WorldTiles : ScriptableObject
{
	public TileBase waterCenter;
	public TileBase waterTop;
	public string waterTopText;
	public TileBase waterBottom;
	public string waterBottomText;
	public TileBase waterLeft;
	public string waterLeftText;
	public TileBase waterRight;
	public TileBase waterTopLeft;
	public TileBase waterTopRight;
	public TileBase waterBottomLeft;
	public TileBase waterBottomRight;

}
