using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIItemButton : MonoBehaviour {

    public PuzzlePiece Item;

    private Button button;
    private Text buttonText;

    public ItemButtonEvent ClickedOnItemButton = new ItemButtonEvent();

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        if (button != null)
        {
            buttonText = GetComponentInChildren<Text>();
            button.onClick.AddListener(ButtonClicked);

            CleanButton();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonClicked()
    {
        if (Item != null)
        {
            ClickedOnItemButton.Invoke(Item);
        }
    }

    public void CleanButton()
    {
        if (buttonText != null)
        {
            buttonText.text = "";
        }

        Item = null;
    }

    public void SetButtonItem(PuzzlePiece piece)
    {
        if (buttonText != null)
        {
            buttonText.text = piece.Name;
        }

        Item = piece;
    }
}

[System.Serializable]
public class ItemButtonEvent : UnityEvent<PuzzlePiece>
{

}
