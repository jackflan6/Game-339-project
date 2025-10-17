using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DialogueDisplayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayCharacterDialogue(string message, GameObject speaker)
    {
        if (speaker.GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            speaker.GetComponentInChildren<TextMeshProUGUI>().text = message;
            print("text created with message: " + message);
        }
        else
        {
            print("text mesh is null");
        }
    }
}
