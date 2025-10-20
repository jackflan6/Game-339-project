using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnityDialogSys : MonoBehaviour, IDialog
{
    [SerializeField] private List<string> preBattleDialogue=new List<string>();

    [SerializeField] private List<string> preBattleCharacterNames = new List<string>();

    [SerializeField] private TextMeshProUGUI battleDialogue;
    [SerializeField] private TextMeshProUGUI battleDialogueCharacterNames;
    private int dialogueCount = 0;
    
    public void EnemyTalk(Enemy enemy, string message)
    {
        GameObject enemyObj = GameObjectManager.allCreatedEnemys[enemy];
        if (enemyObj.GetComponent<DialogueDisplayer>() == null)
        {
            enemyObj.AddComponent<DialogueDisplayer>();
        }
        enemyObj.GetComponent<DialogueDisplayer>().DisplayCharacterDialogue(message,enemyObj);
    }
    
    public void DisplayBattleStartDialogue()
    {
        if (preBattleDialogue.Count != preBattleCharacterNames.Count)
        {
            print("The dialogue lines does not match the number of speak labels");
            return;
        }
        if (dialogueCount == preBattleDialogue.Count)
        {
            battleDialogue.transform.parent.gameObject.SetActive(false);
            return;
        }
        print(preBattleDialogue[dialogueCount]);
        battleDialogueCharacterNames.text = preBattleCharacterNames[dialogueCount];
        battleDialogue.text = preBattleDialogue[dialogueCount];
        dialogueCount++;
    }
    
    
}
