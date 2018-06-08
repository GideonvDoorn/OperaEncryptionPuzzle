using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitcher : MonoBehaviour {

    public CameraSwitcher cameraSwitcher;
    public Transform ToPos;

    public void SwitchRooms()
    {
        cameraSwitcher.SwitchCameras(ToPos);
    }
}
