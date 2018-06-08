using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour {

    public PuzzlePiece piece;

    public bool RemoveAfterPickup = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public PuzzlePiece TakePiece()
    {
        PuzzlePiece p = piece;
        if (RemoveAfterPickup)
        {
            this.gameObject.SetActive(false);
        }

        piece = null;
        return p;
    }
}
