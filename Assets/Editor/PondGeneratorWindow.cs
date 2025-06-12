using UnityEngine;
using UnityEditor;

public class PondGeneratorWindow : EditorWindow
{
    private PondGenerator   pondGenerator;
    private int             pondWidth;
    private int             pondHeight;
    private int             pondx;
    private int             pondy;

    [MenuItem("Tools/Pond Generator")]
    public static void ShowWindow()
    {
        GetWindow<PondGeneratorWindow>("Pond Generator");
    }

    private void OnEnable()
    {
        pondGenerator = FindFirstObjectByType<PondGenerator>();
    }


    void OnGUI()
    {
        GUILayout.Label("Soon to be pond generator!", EditorStyles.boldLabel);

        pondGenerator = EditorGUILayout.ObjectField("Pond Generator", pondGenerator, typeof(PondGenerator), true) as PondGenerator;
        pondWidth = EditorGUILayout.IntField("Pond Width", pondWidth);
        pondHeight = EditorGUILayout.IntField("Pond Height", pondHeight);
        pondx = EditorGUILayout.IntField("Pond x Start", pondx);
        pondy = EditorGUILayout.IntField("Pond y Start", pondy);

        EditorGUILayout.Space();

        // Bouton pour rechercher un PondGenerator dans la scène
        if (GUILayout.Button("Find PondGenerator in Scene"))
        {
            pondGenerator = FindFirstObjectByType<PondGenerator>();
            if (pondGenerator != null)
            {
                Debug.Log($"Found PondGenerator: {pondGenerator.gameObject.name}");
            }
            else
            {
                Debug.LogWarning("No PondGenerator found in the scene!");
            }
        }

        EditorGUILayout.Space();

        // Bouton pour générer la mare
        if (GUILayout.Button("Generate Pond"))
        {
            if (pondGenerator != null)
            {
                pondGenerator.GeneratePond(pondWidth, pondHeight, pondx, pondy);
                Debug.Log("Pond generated.");
            }
            else
            {
                Debug.LogWarning("No PondGenerator assigned! Please assign one.");
            }
        }
    }
}
