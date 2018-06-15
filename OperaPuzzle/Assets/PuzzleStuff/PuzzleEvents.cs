using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleEvents : MonoBehaviour {

    public PieceDoesNotFitInPuzzleEvent PieceDoesNotFitInPuzzle = new PieceDoesNotFitInPuzzleEvent();
    public PieceDoesNotFitInSlotEvent PieceDoesNotFitInSlot = new PieceDoesNotFitInSlotEvent();

    public PlacePieceInSlotEvent PlacePieceInSlot = new PlacePieceInSlotEvent();
    public ReplacePieceInSlotEvent ReplacePieceInSlot = new ReplacePieceInSlotEvent();

    public PuzzleSolvedEvent PuzzleSolved = new PuzzleSolvedEvent();

    public TakePieceEvent TakePiece = new TakePieceEvent();

    public PuzzleFailedWithReturnEvent PuzzleFailedWithReturn = new PuzzleFailedWithReturnEvent();

    public PuzzleFailedEvent PuzzleFailed = new PuzzleFailedEvent();

    public PuzzleClickedEvent PuzzleClicked = new PuzzleClickedEvent();

    public CheckPuzzleEvent CheckPuzzle = new CheckPuzzleEvent();

    public void Awake()
    {
        //PieceDoesNotFitInPuzzle = new PieceDoesNotFitInPuzzleEvent();
        //PieceDoesNotFitInSlot = new PieceDoesNotFitInSlotEvent();
        //
        //PlacePieceInSlot = new PlacePieceInSlotEvent();
        //ReplacePieceInSlot = new ReplacePieceInSlotEvent();
        //
        //PuzzleSolved = new PuzzleSolvedEvent();
        //
        //TakePiece = new TakePieceEvent();
        //
        //PuzzleFailedWithReturn = new PuzzleFailedWithReturnEvent();
        //
        //PuzzleFailed = new PuzzleFailedEvent();
        //
        //PuzzleClicked = new PuzzleClickedEvent();
        //
        //CheckPuzzle = new CheckPuzzleEvent();
    }

}

[System.Serializable]
public class PieceDoesNotFitInPuzzleEvent : UnityEvent<Puzzle>
{

}

[System.Serializable]
public class PieceDoesNotFitInSlotEvent : UnityEvent<PuzzleSlot>
{

}

[System.Serializable]
public class PlacePieceInSlotEvent : UnityEvent<PuzzlePiece>
{

}

[System.Serializable]
public class ReplacePieceInSlotEvent : UnityEvent<PuzzlePiece, PuzzlePiece>
{

}

[System.Serializable]
public class PuzzleSolvedEvent : UnityEvent<Puzzle, PuzzleCollection>
{

}

[System.Serializable]
public class TakePieceEvent : UnityEvent<PuzzlePiece>
{

}

[System.Serializable]
public class PuzzleFailedWithReturnEvent : UnityEvent<Puzzle, PuzzleCollection>
{

}

[System.Serializable]
public class PuzzleFailedEvent : UnityEvent<Puzzle>
{

}

[System.Serializable]
public class PuzzleClickedEvent : UnityEvent
{

}

[System.Serializable]
public class CheckPuzzleEvent : UnityEvent
{

}

[System.Serializable]
public class PuzzleCollection
{
    private PuzzlePiece[] pieces;

    public PuzzleCollection(PuzzlePiece[] pieces)
    {
        this.pieces = pieces;
    }

    public PuzzlePiece[] Pieces{ get {return pieces;}}
}