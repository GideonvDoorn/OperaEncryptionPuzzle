using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToHighlight : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    private bool hitting = false;

    CameraPosition highlighted;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ray = new Ray(this.transform.position, this.transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(ray, out hit))
        {
            CameraPosition cameraPos = hit.collider.GetComponent<CameraPosition>();
            
            if (!hitting && cameraPos != null)
            {
                Debug.Log("hit room");
                hitting = true;
                cameraPos.SetHighlight(true);
                highlighted = cameraPos;
            }
            else if(hitting && cameraPos == null)
            {
                hitting = false;
                highlighted.SetHighlight(false);
                Debug.Log("!hit room");
            }
        }
    }
}
