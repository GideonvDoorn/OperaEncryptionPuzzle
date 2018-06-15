using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PuzzleEvents))]
public class Puzzle : MonoBehaviour {

    public Puzzle PuzzleID;

    public Inventory Inventory;
    public bool Rewarded = false;

    public PuzzlePiece[] Reward;

    public PuzzleEvents EventContainer;

    [HideInInspector]
    private static int nextID = 0;

    public void Awake()
    {
        EventContainer = GetComponent<PuzzleEvents>();
    }

    // Use this for initialization
    public void Start() {
        PuzzleID = this;
    }

    // Update is called once per frame
    void Update() {

    }

    public void DispenseReward()
    {
        if (!Rewarded)
        {
            if (Inventory != null)
            {
                PuzzleSolved();
                Inventory.AddToInventory(Reward);
            }
            Rewarded = true;
        }
    }

    public void PieceDoesNotFitInPuzzle()
    {
        EventContainer.PieceDoesNotFitInPuzzle.Invoke(this);
    }

    public void PieceDoesNotFitInSlot(PuzzleSlot slot)
    {
        EventContainer.PieceDoesNotFitInSlot.Invoke(slot);
    }

    public void PlacePieceInSlot(PuzzlePiece piece)
    {
        EventContainer.PlacePieceInSlot.Invoke(piece);
    }

    public void ReplacePieceInSlot(PuzzlePiece newPiece, PuzzlePiece oldPiece)
    {
        EventContainer.ReplacePieceInSlot.Invoke(newPiece, oldPiece);
    }

    public void PuzzleSolved()
    {
        EventContainer.PuzzleSolved.Invoke(this, new PuzzleCollection(Reward));
    }

    public void TakePiece(PuzzlePiece piece)
    {
        EventContainer.TakePiece.Invoke(piece);
    }

    public void PuzzleFailedWithReturn(List<PuzzlePiece> pieces)
    {
        EventContainer.PuzzleFailedWithReturn.Invoke(this, new PuzzleCollection(pieces.ToArray()));
    }

    public void PuzzleFailed()
    {
        EventContainer.PuzzleFailed.Invoke(this);
    }

    public void PuzzleClicked()
    {
        EventContainer.PuzzleClicked.Invoke();
    }

    public void CheckPuzzle()
    {
        EventContainer.CheckPuzzle.Invoke();
    }

}