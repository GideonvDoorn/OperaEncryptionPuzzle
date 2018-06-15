using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Puzzle))]
public class CollectionPuzzle : MonoBehaviour {

    public Puzzle PuzzleID
    {
        get { return basePuzzle; }
    }

    public PuzzlePiece[] Solution;

    private List<PuzzlePiece> pieces = new List<PuzzlePiece>();

    public bool OrderedPuzzle = false;

    private Puzzle basePuzzle;

    public void Awake()
    {
        basePuzzle = GetComponent<Puzzle>();
    }
    
    void Start () {
        foreach (PuzzlePiece p in Solution)
        {
            p.PuzzleID = PuzzleID;
        }
    }

    public void PutPuzzlePiece(Inventory inventory)
    {
        
        if (inventory.CurrentPuzzlePiece != null)
        {
            
            if (inventory.CurrentPuzzlePiece.PuzzleID == PuzzleID)
            {
                
                basePuzzle.PlacePieceInSlot(inventory.CurrentPuzzlePiece);
                pieces.Add(inventory.TakeCurrentItem());
            }
            else
            {

                basePuzzle.PieceDoesNotFitInPuzzle();
            }
        }

        if (pieces.Count == Solution.Length)
        {
            CheckSolution(inventory);
        }

    }

    public void CheckSolution(Inventory inventory)
    {
        bool correct = true;

        basePuzzle.CheckPuzzle();

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

        if (correct)
        {
            basePuzzle.DispenseReward();
        }
        else
        {
            basePuzzle.PuzzleFailedWithReturn(pieces);
            ReturnPieces(inventory);
        }

        //return correct;
    }

    private void ReturnPieces(Inventory inventory)
    {
        foreach (PuzzlePiece piece in pieces)
        {
            inventory.AddToInventory(piece);
        }

        pieces.Clear();
    }

}
