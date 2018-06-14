using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PuzzleEvents))]
public class Puzzle : MonoBehaviour {

    public int PuzzleID;

    public PuzzlePiece[] Solution;

    private List<PuzzlePiece> pieces = new List<PuzzlePiece>();

    public bool OrderedPuzzle = false;

    public Inventory Inventory;
    private bool rewarded = false;

    public UnityEvent SolvedEvent = new UnityEvent();

    public PuzzlePiece[] Reward;

    [HideInInspector]
    public static int nextID = 0;

	// Use this for initialization
	public virtual void Start () {
        PuzzleID = nextID++;
        foreach (PuzzlePiece p in Solution)
        {
            p.PuzzleID = PuzzleID;
        }

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PutPuzzlePiece(Inventory inventory)
    {
        if (inventory.CurrentPuzzlePiece != null)
        {
            pieces.Add(inventory.TakeCurrentItem());
            //inventory.CurrentPuzzlePiece.MovePiece(this.transform, false, false);
        }

        if (pieces.Count == Solution.Length)
        {
            if (CheckSolution())
            {
                DispenseReward();
            }
            else
            {
                foreach (PuzzlePiece piece in pieces)
                {
                    inventory.AddToInventory(piece);
                }

                pieces.Clear();
            }
        }        

    }

    public virtual bool CheckSolution()
    {
        bool correct = true;

        if (OrderedPuzzle)
        {
            for (int i = 0; i < Solution.Length; i++)
            {
                if (Solution[i] != pieces[i])
                {
                    correct = false;
                }
            }
        }
        else
        {
            foreach (PuzzlePiece piece in Solution)
            {
                if (!pieces.Contains(piece))
                {
                    correct = false;
                }
            }
        }

        return correct;
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