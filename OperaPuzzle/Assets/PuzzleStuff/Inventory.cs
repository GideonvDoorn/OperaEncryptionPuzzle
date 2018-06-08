using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour {

    public PuzzlePiece CurrentPuzzlePiece;

    public List<PuzzlePiece> Items = new List<PuzzlePiece>();

    public UnityEvent CurrentItemChanged = new UnityEvent();
    public UnityEvent InventoryItemChanged = new UnityEvent();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddToInventory(PuzzlePiece piece)
    {
        if (piece != null)
        {
            Items.Add(piece);
            piece.MovePiece(this.transform, false, false);
            InventoryItemChanged.Invoke();

        }
    }

    public void AddToInventory(PuzzlePiece[] pieces)
    {
        foreach (PuzzlePiece piece in pieces)
        {
            Items.Add(piece);
            piece.MovePiece(this.transform, false, false);
        }
        InventoryItemChanged.Invoke();
    }

    public void ChangeSelected(PuzzlePiece piece, bool invokeEvent)
    {
        CurrentPuzzlePiece = piece;

        if (invokeEvent)
        {

            CurrentItemChanged.Invoke();
        }
    }

    public PuzzlePiece TakeCurrentItem()
    {
        PuzzlePiece piece = CurrentPuzzlePiece;
        CurrentPuzzlePiece = null;

        Items.Remove(piece);

        CurrentItemChanged.Invoke();
        InventoryItemChanged.Invoke();
        return piece;
    }

    public bool HasObject(PuzzlePiece obj)
    {
        foreach(PuzzlePiece p in Items)
        {
            if(p.Name == obj.Name)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveObject(PuzzlePiece obj)
    {
         Items.Remove(obj);
        if (CurrentPuzzlePiece == obj)
        {
            CurrentPuzzlePiece = null;
        }

        InventoryItemChanged.Invoke();
        CurrentItemChanged.Invoke();

    }
}
