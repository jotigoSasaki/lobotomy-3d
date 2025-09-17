using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(CreateToggleOfRooms))]
public class CreateToggleOfRoomsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CreateToggleOfRooms myScript = (CreateToggleOfRooms)target;
        if (GUILayout.Button("Run Script"))
        {
            myScript.Run();
        }
    }
}
