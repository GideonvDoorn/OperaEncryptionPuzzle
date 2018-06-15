using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Puzzle))]
public class SlottedPuzzle : MonoBehaviour
{

    public PuzzleSolutionPair[] Solution;

    public Puzzle PuzzleID
    {
        get { return basePuzzle; }
    }

    public bool Rewarded { get { return basePuzzle.Rewarded; } }

    private Puzzle basePuzzle;

    public void Awake()
    {
        basePuzzle = GetComponent<Puzzle>();
    }

    // Use this for initialization
    public void Start () {
        
        foreach (PuzzleSolutionPair item in Solution)
        {
            item.PuzzleSlot.Initialize(this, item.PuzzlePiece);
            item.PuzzlePiece.PuzzleID = basePuzzle;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void CheckSolution()
    {
        bool correct = true;
        foreach (PuzzleSolutionPair item in Solution)
        {
            if (!item.PuzzleSlot.CorrectPiece())
            {
                correct = false;
            }
        }

        if (correct)
        {
            SolvePuzzle();
        }
        else
        {
            basePuzzle.PuzzleFailed();
        }

    }

    public void SolvePuzzle()
    {
        basePuzzle.DispenseReward();
    }

    public void PieceDoesNotFitInSlot(PuzzleSlot slot)
    {
        basePuzzle.PieceDoesNotFitInSlot(slot);
    }

    public void TakePiece(PuzzlePiece piece)
    {
        basePuzzle.TakePiece(piece);
    }

    public void PlacePieceInSlot(PuzzlePiece piece)
    {
        basePuzzle.PlacePieceInSlot(piece);
    }

}


[System.Serializable]
public class PuzzleSolutionPair
{
    public PuzzlePiece PuzzlePiece;
    public PuzzleSlot PuzzleSlot;
}

