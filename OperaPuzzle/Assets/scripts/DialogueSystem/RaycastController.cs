using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RaycastController : MonoBehaviour
{

    public bool TouchInput;
    public CameraInput cameraInputScript;
    public UnityEvent Evt_OnSwitchToObjectView;


    void Update()
    {
        if (TouchInput)
        {
            //touch input not tested

            if(Input.touches.Length > 0)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;

                    if (hit.collider.GetComponent<Interactable>() != null)
                    {
                        hit.collider.GetComponent<Interactable>().Evt_OnInteract.Invoke();
                    }
                }
            }

        }
        else {
            
            if (Input.GetMouseButtonDown(0))
             {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit))
                    {
                        Transform objectHit = hit.transform;


                        if (hit.collider.GetComponent<CameraPosition>() != null)
                        {
                            StartCoroutine(MoveToPosition(hit.collider.GetComponent<CameraPosition>(), 2));
                            //Camera.main.transform.position = hit.collider.GetComponent<CameraPosition>().transform.position;
                            //Camera.main.transform.rotation = hit.collider.GetComponent<CameraPosition>().transform.rotation;


                        }
                        else if (hit.collider.GetComponent<ObjectViewPosition>() != null)
                        {
                            Camera.main.transform.position = hit.collider.GetComponent<ObjectViewPosition>().transform.position;
                            Camera.main.transform.rotation = hit.collider.GetComponent<ObjectViewPosition>().transform.rotation;
                            Evt_OnSwitchToObjectView.Invoke();
                            cameraInputScript.AllowRotation = false;
                        }
                        else if (hit.collider.GetComponent<Interactable>() != null)
                        {
                            hit.collider.GetComponent<Interactable>().Evt_OnInteract.Invoke();
                        }
                        else if (hit.collider.GetComponent<RoomSwitcher>() != null)
                        {
                            hit.collider.GetComponent<RoomSwitcher>().SwitchRooms(); ;
                        }
                    }
                }
            }
        }

       

    }

    IEnumerator MoveToPosition(CameraPosition targetPosition,float time)
    {
        float elapsedTime = 0;
        Vector3 startingPosition = transform.position;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition.transform.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
