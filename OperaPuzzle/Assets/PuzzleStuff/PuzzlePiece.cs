using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour {

    public Puzzle PuzzleID;

    new private Collider collider;

    public string Name;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        this.transform.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MovePiece(Transform transform, bool enabled, bool clickable)
    {
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;

        this.transform.gameObject.SetActive(enabled);

        if (collider != null)
        {
            collider.enabled = clickable;
        }
    }
}
