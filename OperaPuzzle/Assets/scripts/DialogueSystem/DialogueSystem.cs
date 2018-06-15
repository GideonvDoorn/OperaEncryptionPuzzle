using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Queue<string> messages;
    public GameObject UIPanel;
    public Text UIText;


    private bool initial = true;


    void Awake()
    {
        messages = new Queue<string>();
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                Cycle();
            }

        }
    }
    public void AddMessage(string message)
    {
        messages.Enqueue(message);

        if (initial == true)
        {

            InitializeMessages();
        }

    }

    public void InitializeMessages()
    {
        UIPanel.SetActive(true);
        Debug.Log("activate panel");
        initial = false;
        Cycle();
    }

    public void EndMessages()
    {
        UIPanel.SetActive(false);
        initial = true;
    }


    public void Cycle()
    {
        if(messages.Count == 0)
        {
            EndMessages();
            return;
        }

        UIText.text = messages.Dequeue();

    }
}
