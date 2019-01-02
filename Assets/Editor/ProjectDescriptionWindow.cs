using UnityEngine;
using UnityEditor;

public class ProjectDescriptionWindow : EditorWindow
{

    [MenuItem("Window/Project Description")]
    public static void ShowWindow()
    {
        GetWindow<ProjectDescriptionWindow>("Project Description");
    }

    void OnGUI()
    {
        GUILayout.Label("Emergent Sound Creator", EditorStyles.boldLabel);
        GUILayout.Label("The game is set to a key by the user (the default is C Maj). \nThere are a few movable and rotatable shapes on the scene. \n" +
            "These shapes interact with each other to spread behaviors depending on their distances.\n" +
            "Close objects will want to emit sounds more frequent if they are of the same shape.\n" +
            "If close objects are of a different shape they will want to emit sounds of chords together\n" +
            "as either an arpeggio or as a sustained chord depending on how close they are.");
    }    
}
