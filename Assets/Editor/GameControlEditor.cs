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

        // Get reference to Game Control script
        GameControl myScript = (GameControl)target;
        // Create button with reset text
        if (GUILayout.Button("Reset High Score"))
        {
            // Reset the high score
            myScript.ResetHighScore();
        }
    }
}
