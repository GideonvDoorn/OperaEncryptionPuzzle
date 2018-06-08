using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour {

    public Text UIText;
    
    [Header("Default Dialogue")]
    public Dialogue DefaultDialogue;

    [Header("Chronological Dialogue")]
    public Dialogue[] ChronologicalDialogues;
    public bool FinishAfterdialogue;

    [Header("Finished Dialogue")]
    public Dialogue FinishedDialogue;
    public PuzzlePiece[] ObjectsNeededToFinish;
    public UnityEvent Evt_OnFinish;

    private int dialogueProgress = 0;

    [System.NonSerialized]
    public bool Finished = false;

    [System.NonSerialized]
    public bool Default = false;


    public void AdvanceDialogue()
    {
        CheckIfFinished();

        if(ChronologicalDialogues == null || ChronologicalDialogues.Length == 0 || Default)
        {
            UIText.text = DefaultDialogue.ShowDialogue();
        }
        else if (Finished)
        {
            if(FinishedDialogue == null)
            {
                Default = true;
                Evt_OnFinish.Invoke();
                return;
            }

            UIText.text = FinishedDialogue.ShowDialogue();
            Evt_OnFinish.Invoke();
            Default = true;
        }
        else
        {
            UIText.text = ChronologicalDialogues[dialogueProgress].ShowDialogue();

            if (dialogueProgress < ChronologicalDialogues.Length - 1)
            {
                dialogueProgress++;
            }
            else if (FinishAfterdialogue)
            {
                Finished = true;
                AdvanceDialogue();
            }
            //else
            //{
            //    Default = true;
            //}
        }
    }

    private void CheckIfFinished()
    {
        if(ObjectsNeededToFinish == null || ObjectsNeededToFinish.Length == 0)
        {
            return;
        }

        foreach(PuzzlePiece obj in ObjectsNeededToFinish)
        {
            if (!GetComponentInParent<Inventory>().HasObject(obj))
            {
                Finished = false;
                return;
            }
        }
        Finished = true;
    }

    public void FinishDialogue()
    {
        Finished = true;
    }
}
