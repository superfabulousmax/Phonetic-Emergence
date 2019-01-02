using UnityEngine;
using UnityEditor;

public class ColorizeWindow : EditorWindow {

    Color col;

    [MenuItem("Window/Object Colourer")]
    public static void ShowWindow()
    {
        GetWindow<ColorizeWindow>("Object Colourer");
    }

    void OnGUI()
    {
        GUILayout.Label("Colour the selected object");

        col = EditorGUILayout.ColorField("Color", col);

        if(GUILayout.Button("Colour"))
        {
            Colour();
        }
    }

    void Colour()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();

            if (renderer != null)
            {
                renderer.sharedMaterial.color = col;
            }
        }
    }
}
