using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CaptureScreen))]
public class CaptureScreenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var cs = target as CaptureScreen;

        if(GUILayout.Button("Save"))
        {
            cs.Save();
        }
    }
}
