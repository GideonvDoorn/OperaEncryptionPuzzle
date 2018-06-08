using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    [TextArea]
    public string dialogueText;
    public UnityEvent Evt_DialogueFinished;

    public string ShowDialogue()
    {
        Evt_DialogueFinished.Invoke();
        return dialogueText;
    }
}
