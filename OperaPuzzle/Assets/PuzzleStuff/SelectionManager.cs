using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Inventory))]
public class SelectionManager : MonoBehaviour {

    public PuzzleSlotClickedEvent ClickedOnPuzzleSlot = new PuzzleSlotClickedEvent();

    private Inventory inventory;

    void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    void Start()
    {

    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {

                    PuzzleSlot puzzleSlot = hit.transform.gameObject.GetComponent<PuzzleSlot>();
                    CollectionPuzzle collectionPuzzle = hit.transform.gameObject.GetComponent<CollectionPuzzle>();
                    PuzzlePieceCycler cycler = hit.transform.gameObject.GetComponent<PuzzlePieceCycler>();
                    Container container = hit.transform.gameObject.GetComponent<Container>();
                    PuzzlePiece piece = hit.transform.gameObject.GetComponent<PuzzlePiece>();

                    if (puzzleSlot != null)
                    {
                        puzzleSlot.UsePuzzleSlot(inventory);
                    }
                    else if (collectionPuzzle != null)
                    {
                        collectionPuzzle.PutPuzzlePiece(inventory);
                    }
                    else if(cycler != null)
                    {
                        cycler.CyclePieces();
                    }
                    else if (container != null)
                    {
                        inventory.AddToInventory(container.TakePiece());
                    }
                    else if (piece != null)
                    {
                        //inventory.ChangeSelected(piece);
                    }

                }
                else
                {//Clicked on "nothing"

                }
            }
            else
            {//Clicked a UI element

            }           

        }

	}
}

[System.Serializable]
public class PuzzleSlotClickedEvent : UnityEvent<PuzzleSlot>
{

}
