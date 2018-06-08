using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CycledPuzzle : MonoBehaviour {

    public CycleSolutionPair[] Solution;

    public int PuzzleID;

    public Inventory Inventory;
    private bool rewarded = false;

    public UnityEvent SolvedEvent = new UnityEvent();

    public PuzzlePiece[] Reward;

    // Use this for initialization
    public void Start () {
        PuzzleID = Puzzle.nextID++;
	}
	
	// Update is called once per frame
	void Update () {
		
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
            DispenseReward();
            Debug.Log("Yay");
        }
        else
        {
            Debug.Log("Nay");
        }
        //return correct;
    }

    private void DispenseReward()
    {
        if (!rewarded)
        {
            if (Inventory != null)
            {
                Inventory.AddToInventory(Reward);
            }
            rewarded = true;
            SolvedEvent.Invoke();
        }
    }
}

[System.Serializable]
public class CycleSolutionPair
{
    public PuzzlePiece PuzzlePiece;
    public PuzzlePieceCycler PuzzleCycler;
}
