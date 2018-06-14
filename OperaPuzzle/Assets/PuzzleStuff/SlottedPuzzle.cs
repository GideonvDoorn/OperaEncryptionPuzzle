using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Puzzle))]
public class SlottedPuzzle : MonoBehaviour
{

    public PuzzleSolutionPair[] Solution;

    public int PuzzleID; //

    public Inventory Inventory; //
    public bool Rewarded = false; //

    public UnityEvent SolvedEvent = new UnityEvent();

    public PuzzlePiece[] Reward; //

    private Puzzle basePuzzle;

    public void Awake()
    {
        basePuzzle = GetComponent<Puzzle>();
    }

    // Use this for initialization
    public void Start () {

        PuzzleID = Puzzle.nextID++;
        
        foreach (PuzzleSolutionPair item in Solution)
        {
            item.PuzzleSlot.Initialize(this, item.PuzzlePiece);
            item.PuzzlePiece.PuzzleID = PuzzleID;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    public bool CheckSolution()
    {
        Debug.Log("Checking");
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

        return correct;

    }

    public void SolvePuzzle()
    {
        
        DispenseReward();
    }

    private void DispenseReward()
    {
        if (!Rewarded)
        {
            if (Inventory != null)
            {
                Debug.Log("Solved");
                Inventory.AddToInventory(Reward);
            }
            Rewarded = true;
            SolvedEvent.Invoke();
        }
    }

}

[System.Serializable]
public class PuzzleSolutionPair
{
    public PuzzlePiece PuzzlePiece;
    public PuzzleSlot PuzzleSlot;
}

