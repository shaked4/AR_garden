using UnityEngine;
using UnityEditor;

public class TreePlacerTool : EditorWindow
{
    GameObject selectedPrefab
{
    get => AssetDatabase.LoadAssetAtPath<GameObject>(EditorPrefs.GetString("TreePlacer_SelectedPrefabPath", ""));
    set
    {
        if (value != null)
        {
            string path = AssetDatabase.GetAssetPath(value);
            EditorPrefs.SetString("TreePlacer_SelectedPrefabPath", path);
        }
        else
        {
            EditorPrefs.DeleteKey("TreePlacer_SelectedPrefabPath");
        }
    }
}


    [MenuItem("Tools/Tree Placer")]
    static void OpenWindow()
    {
        GetWindow<TreePlacerTool>("Tree Placer");
    }

    void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    void OnGUI()
    {
        GUILayout.Label("Select a Prefab to Place", EditorStyles.boldLabel);
        selectedPrefab = (GameObject)EditorGUILayout.ObjectField("Prefab", selectedPrefab, typeof(GameObject), false);
        EditorGUILayout.HelpBox("Click in the Scene to place the selected prefab.", MessageType.Info);
    }

    void OnSceneGUI(SceneView sceneView)
    {
        if (selectedPrefab == null)
            return;

        Event e = Event.current;

        if (e.type == EventType.MouseDown && e.button == 0 && !e.alt)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject placed = (GameObject)PrefabUtility.InstantiatePrefab(selectedPrefab);
                placed.transform.position = hit.point;
                Undo.RegisterCreatedObjectUndo(placed, "Place Prefab");
                e.Use();
            }
        }
    }
}
