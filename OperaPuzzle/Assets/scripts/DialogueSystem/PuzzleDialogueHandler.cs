using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDialogueHandler : MonoBehaviour {

    public DialogueSystem dialogueSystem;

    public MessageComponent FoundPieceMessage;
    public MessageComponent PuzzleSolvedMessage;
    public MessageComponent PuzzleFailedMessage;
    public MessageComponent PiecePutFailedMessage;
    public MessageComponent PutPieceMessage;
    public MessageComponent TakePieceMessage;


    public void PutPiece(PuzzlePiece piece, Puzzle puzzle, MessageComponent customMessage)
    {
        dialogueSystem.AddMessage(string.Format(PutPieceMessage.GetMessageText(), piece.name, puzzle.name));
    }

    public void PuzzleSolved(Puzzle puzzle, List<PuzzlePiece> rewards, MessageComponent customMessage)
    {
        dialogueSystem.AddMessage(string.Format(PuzzleSolvedMessage.GetMessageText()));
        foreach (PuzzlePiece piece in rewards)
        {
            dialogueSystem.AddMessage(string.Format(FoundPieceMessage.GetMessageText(), piece.name));
        }
    }

    public void PuzzleFailed(Puzzle puzzle, MessageComponent customMessage)
    {
        dialogueSystem.AddMessage(PuzzleFailedMessage.GetMessageText());

    }

    public void PiecePutFailed(Puzzle puzzle, MessageComponent customMessage)
    {
        dialogueSystem.AddMessage(string.Format(PiecePutFailedMessage.GetMessageText()));

    }

    public void TakePiece(PuzzlePiece piece, MessageComponent customMessage)
    {
        dialogueSystem.AddMessage(string.Format(TakePieceMessage.GetMessageText(), piece.name));
        
    }

    public void FoundPiece(PuzzlePiece piece, MessageComponent customMessage)
    {
        dialogueSystem.AddMessage(string.Format(FoundPieceMessage.GetMessageText(), piece.name));

    }

    public void SwapPiece(PuzzlePiece put, PuzzlePiece got, MessageComponent customMessage)
    {
        dialogueSystem.AddMessage(string.Format(TakePieceMessage.GetMessageText(), put.name));
        dialogueSystem.AddMessage(string.Format(PutPieceMessage.GetMessageText(), put.name));
    }
     
    public void ShowMessage(MessageComponent messageComponent)
    {
        dialogueSystem.AddMessage(messageComponent.GetMessageText());
    }
}
