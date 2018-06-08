using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour {

    public Inventory Inventory;

    public UIItemButton[] ItemButtons;

    public Text CurrentItemText;

    public UIInventory SmallInventory;

	// Use this for initialization
	void Start () {

        if (Inventory != null)
        {
            ItemButtons = GetComponentsInChildren<UIItemButton>();

            //Inventory.CurrentItemChanged.AddListener(RebuildInventoryButtons);
            //Inventory.CurrentItemChanged.AddListener(ChangeCurrentItem);
            if (ItemButtons.Length > 0)
            {
                Inventory.InventoryItemChanged.AddListener(RebuildInventoryButtons);

                foreach (UIItemButton button in ItemButtons)
                {
                    button.ClickedOnItemButton.AddListener(ItemButtonClicked);
                }
            }
        }

        CloseBigInventory();
    }

    public void ItemButtonClicked(PuzzlePiece piece)
    {
        Inventory.ChangeSelected(piece, true);
        CloseBigInventory();
    }

    public void CloseBigInventory()
    {

        if (SmallInventory != null)
        {
            SmallInventory.transform.gameObject.SetActive(true);

            SmallInventory.ChangeCurrentItem();

            this.transform.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeCurrentItem()
    {
        if (Inventory.CurrentPuzzlePiece != null)
        {
            CurrentItemText.text = "Current Item: " + Inventory.CurrentPuzzlePiece.Name;
        }
        else
        {
            CurrentItemText.text = "Current Item: ";
        }
    }

    public void RebuildInventoryButtons()
    {
        foreach (UIItemButton iButton in ItemButtons)
        {
            iButton.CleanButton();
        }

        int i = 0;
        foreach (PuzzlePiece piece in Inventory.Items)
        {
            ItemButtons[i].SetButtonItem(piece);
            i++;
        }

        ChangeCurrentItem();
        SmallInventory.ChangeCurrentItem();

    }
}
