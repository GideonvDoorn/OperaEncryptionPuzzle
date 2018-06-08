using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PuzzlePieceCycler : MonoBehaviour {

    public PuzzlePiece[] Pieces;

    public PuzzlePiece CurrentPiece;
    private int currentIndex = 0;

	// Use this for initialization
	void Start () {
        if (Pieces != null)
        {
            SetCurrentPiece(currentIndex);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CyclePieces()
    {
        currentIndex++;
        currentIndex = currentIndex % Pieces.Length;

        SetCurrentPiece(currentIndex);
    }

    private void SetCurrentPiece(int index)
    {
        if (CurrentPiece != null)
        {
            CurrentPiece.MovePiece(this.transform, false, false);
        }
        if (Pieces.Length > 0)
        {

            CurrentPiece = Pieces[index];

            CurrentPiece.MovePiece(this.transform, true, false);
        }
    }
}
