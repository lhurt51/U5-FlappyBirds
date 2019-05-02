using System.Collections;
using UnityEngine;

// Including the editor header
using UnityEditor;

[CustomEditor(typeof(GameControl))]
public class GameControllerEditor : Editor
{
    // Override the inspector GUI Instantiation
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawDefaultInspector();

        GameControl myScript = (GameControl)target;
        if (GUILayout.Button("Reset High Score"))
        {
            myScript.ResetHighScore();
        }
    }
}
