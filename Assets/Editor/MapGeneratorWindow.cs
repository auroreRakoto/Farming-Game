using UnityEditor;
using UnityEngine;

public class MapGeneratorWindow : EditorWindow
{
	private MapGenerator	mapGenerator;
	public WorldData		worldData;

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

		if (GUILayout.Button("Generate Map"))
		{
			mapGenerator.GenerateMap();
		}
	}
}
