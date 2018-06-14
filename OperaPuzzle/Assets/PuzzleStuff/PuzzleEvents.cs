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

}

public class PieceDoesNotFitInPuzzleEvent : UnityEvent<Puzzle>
{

}

public class PieceDoesNotFitInSlotEvent : UnityEvent<PuzzleSlot>
{

}

public class PlacePieceInSlotEvent : UnityEvent<PuzzlePiece>
{

}

public class ReplacePieceInSlotEvent : UnityEvent<PuzzlePiece, PuzzlePiece>
{

}

public class PuzzleSolvedEvent : UnityEvent<Puzzle, PuzzleCollection>
{

}

public class TakePieceEvent : UnityEvent<PuzzlePiece>
{

}

public class PuzzleFailedWithReturnEvent : UnityEvent<Puzzle, PuzzleCollection>
{

}

public class PuzzleFailedEvent : UnityEvent<Puzzle>
{

}

public class PuzzleClickedEvent : UnityEvent
{

}

public class PuzzleCollection
{
    private List<PuzzlePiece> pieces;

    public PuzzleCollection(List<PuzzlePiece> pieces)
    {
        this.pieces = pieces;
    }

    public List<PuzzlePiece> Pieces{ get {return pieces;}}
}