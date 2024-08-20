using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AStarAgent3DExample))]
public class AStarAgent3DExampleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AStarAgent3DExample script = (AStarAgent3DExample)target;
        if (GUILayout.Button("Start")){
            script.Setup();
        }
        if (GUILayout.Button("Reset")){
            script.Reset();
        }
    }
}