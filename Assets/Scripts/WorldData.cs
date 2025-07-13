using UnityEngine;

[CreateAssetMenu(fileName = "NewWorldData", menuName = "World/WorldData")]
public class WorldData : ScriptableObject
{
	public int			width;
	public int			height;
	public Vector2Int	origin;
	public float		groundNoiseScale;
	public float		groundMinTreshold;
	public float		groundMaxTreshold;
	public float		waterMinTreshold;
	public float		waterMaxTreshold;
	public string		houseScene;
	public string		outsideScene;
}
