using UnityEngine;
using UnityEngine.UI;

public class CreateToggleOfRooms : MonoBehaviour
{
    // create toogle with name of Gameobjects tag
    public GameObject TragetToAddChilds;
    public GameObject GameobjectToCreate;
    public string tagForName = "Room";
    public void Run()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tagForName);
        foreach (GameObject gameObject in gameObjects) {
          var obj =   Instantiate(GameobjectToCreate, TragetToAddChilds.transform);
           obj.name = "Toggle"+gameObject.name;
            var toggleComponent = obj.GetComponent<Toggle>();
            toggleComponent.group = TragetToAddChilds.GetComponent<ToggleGroup>();
        }
    }
}
