using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CameraPosition : MonoBehaviour
{
    public GameObject Highlight;

    public void SetHighlight(bool active)
    {
        Highlight.SetActive(active);
    }

}
