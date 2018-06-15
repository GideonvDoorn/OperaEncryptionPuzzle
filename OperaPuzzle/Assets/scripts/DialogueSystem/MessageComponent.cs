using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageComponent : MonoBehaviour {

    [TextArea]
    public string messageText;


    public string GetMessageText()
    {
        return messageText;
    }

}
