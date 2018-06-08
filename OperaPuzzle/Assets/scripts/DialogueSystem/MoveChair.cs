using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChair : MonoBehaviour {

    public Transform MoveToLocation;

    public void Move()
    {
        this.transform.position = MoveToLocation.position;
    }
}
