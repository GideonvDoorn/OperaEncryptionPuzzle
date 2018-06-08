using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour {
    
    private SlottedPuzzle puzzle;
    private PuzzlePiece correctPiece;
    private PuzzlePiece currentPiece;


    public void Initialize(SlottedPuzzle puzzle, PuzzlePiece correctPiece)
    {
        this.puzzle = puzzle;
        this.correctPiece = correctPiece;
    }

    public bool CorrectPiece()
    {
        return currentPiece == correctPiece;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UsePuzzleSlot(Inventory inventory)
    {
        if (!puzzle.Rewarded)
        {

            if (currentPiece != null)
            {
                inventory.AddToInventory(currentPiece);
                currentPiece = null;
            }

            if (inventory.CurrentPuzzlePiece != null)
            {
                if (puzzle.PuzzleID == inventory.CurrentPuzzlePiece.PuzzleID)
                {
                    currentPiece = inventory.TakeCurrentItem();
                    currentPiece.MovePiece(this.transform, true, false);
                }
            }

            puzzle.CheckSolution();
        }

    }
}
