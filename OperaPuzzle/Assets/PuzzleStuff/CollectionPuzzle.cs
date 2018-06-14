using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Puzzle))]
public class CollectionPuzzle : MonoBehaviour {

    public int PuzzleID; //

    public PuzzlePiece[] Solution;

    private List<PuzzlePiece> pieces = new List<PuzzlePiece>();

    public bool OrderedPuzzle = false;

    private Puzzle basePuzzle;

    public void Awake()
    {
        basePuzzle = GetComponent<Puzzle>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
