
#if UNITY_EDITOR 
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InputFieldGridGenerator))]
public class InputFieldGridGeneratorEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InputFieldGridGenerator generator = (InputFieldGridGenerator) target;
        if (GUILayout.Button("Generate Grid"))
        {
            generator.GenerateGrid();
        }

    }
}
#endif