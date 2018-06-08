using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour, IPointerClickHandler
{
    public bool DetectViaRaycast;

    public UnityEvent Evt_OnInteract;

    public void OnPointerClick(PointerEventData eventData )
    {
        if (DetectViaRaycast)
        {
            return;
        }

        Evt_OnInteract.Invoke();
    }
}
