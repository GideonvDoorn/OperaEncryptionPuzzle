using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Puzzle))]
public class CycledPuzzle : MonoBehaviour {

    public CycleSolutionPair[] Solution;

    public Puzzle PuzzleID
    {
        get { return basePuzzle; }
    }
    private Puzzle basePuzzle;

    public void Awake()
    {
        basePuzzle = GetComponent<Puzzle>();
    }

    public void CheckSolution()
    {
        bool correct = true;

        foreach (CycleSolutionPair pair in Solution)
        {
            if (pair.PuzzleCycler.CurrentPiece != pair.PuzzlePiece)
            {
                correct = false;
            }
        }

        if (correct)
        {
            basePuzzle.DispenseReward();
        }
        else
        {
            basePuzzle.PuzzleFailed();
        }
    }
    
}

[System.Serializable]
public class CycleSolutionPair
{
    public PuzzlePiece PuzzlePiece;
    public PuzzlePieceCycler PuzzleCycler;
}
