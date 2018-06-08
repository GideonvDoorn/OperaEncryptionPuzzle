using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInput : MonoBehaviour {

    public int Speed;
    public bool AllowRotation = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (AllowRotation)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Rotate(Vector3.down * Speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Rotate(Vector3.up * Speed);
            }
        }

    }
    public void SetAllowRotation(bool allow)
    {
        AllowRotation = allow;
    }

}
