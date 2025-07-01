using UnityEditor;
using UnityEngine;

public class MapGeneratorWindow : EditorWindow
{
	private MapGenerator	mapGenerator;
	public WorldData		worldData;
    private int				maspSeed;

	[MenuItem("Tools/Map Generator")]
	public static void ShowWindow()
	{
		GetWindow<MapGeneratorWindow>("Map Generator");
	}

	private void OnEnable()
	{
		mapGenerator = FindFirstObjectByType<MapGenerator>();
	}

	void OnGUI()
	{
		GUILayout.Label("Soon to be map generator!", EditorStyles.boldLabel);

		EditorGUILayout.Space();
        
        maspSeed = EditorGUILayout.IntField("Map Seed", maspSeed);

		if (GUILayout.Button("Generate Map"))
		{
			mapGenerator.GenerateMap(maspSeed);
		}
        
        EditorGUILayout.Space();

		if (GUILayout.Button("Clear Map"))
		{
			mapGenerator.ClearMap();
		}
	}
}
