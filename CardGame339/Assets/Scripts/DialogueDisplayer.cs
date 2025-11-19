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
        if (speaker.GetComponentInChildren<TextMeshPro>() != null)
        {
            speaker.GetComponentInChildren<TextMeshPro>().text = message;
            ManagerManager.Resolve<IGameLogger>().print("text created with message: " + message);
        }
        else
        {
            ManagerManager.Resolve<IGameLogger>().Error("text mesh is null");
        }
    }
    
    
}
