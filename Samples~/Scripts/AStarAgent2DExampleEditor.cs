using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AStarAgent2DExample))]
public class AStarAgent2DExampleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AStarAgent2DExample script = (AStarAgent2DExample)target;
        if (GUILayout.Button("Start")){
            script.Setup();
        }
        if (GUILayout.Button("Reset")){
            script.Reset();
        }
    }
}