using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// Toggle name are Toggle[name of cameras room]
public class CameraChangingToggles : MonoBehaviour
{
    // key is name of room of camera gameobject
    // bolor cameranerin hamapatasxanum e jurorinak room | heto karoxa petq e dzel
    public Dictionary<string,GameObject> SecurityCameras;
    public GameObject ToggleGroupGameObject;
    public Toggle[] CameraToggles;
    public string currentCamName ;

    void Awake()
    {
        
        CameraToggles = ToggleGroupGameObject.GetComponentsInChildren<Toggle>(true);

        SecurityCameras = new Dictionary<string, GameObject>();
        var SecurityCamerasArray = GameObject.FindGameObjectsWithTag("SecurityCamera");
        foreach (var SecurityCam in SecurityCamerasArray)
        {
            SecurityCameras.Add(SecurityCam.transform.parent.name, SecurityCam);
        }

        foreach(var Toggle in CameraToggles)
        {
            Toggle.onValueChanged.AddListener((bool isOn) =>
            {
                var SecurityCameraName = Toggle.gameObject.name.Replace("Toggle","");
                var SecurityCamera = SecurityCameras[SecurityCameraName];
                var CameraComponent = SecurityCamera.GetComponent<Camera>();
                CameraComponent.enabled = isOn;
            });
        }
    }

}
