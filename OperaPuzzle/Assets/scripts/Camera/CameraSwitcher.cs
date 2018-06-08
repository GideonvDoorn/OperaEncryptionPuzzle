using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraSwitcher : MonoBehaviour
{
    public CameraInput cameraInputScript;
    public UnityEvent Evt_OnSwitchToObjectView;

    public void SwitchCameras(Transform switchTo)
    {
        Camera.main.transform.position = switchTo.position;
        Camera.main.transform.rotation = switchTo.rotation;
        Evt_OnSwitchToObjectView.Invoke();
    }
}
