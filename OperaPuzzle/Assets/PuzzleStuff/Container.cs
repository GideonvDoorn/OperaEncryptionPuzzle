using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PuzzleEvents))]
public class Container : MonoBehaviour {

    public PuzzlePiece piece;

    public bool RemoveAfterPickup = true;

    public PuzzleEvents EventContainer;

    public void Awake()
    {
        EventContainer = GetComponent<PuzzleEvents>();
    }

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

        EventContainer.TakePiece.Invoke(p);

        return p;
    }
}
