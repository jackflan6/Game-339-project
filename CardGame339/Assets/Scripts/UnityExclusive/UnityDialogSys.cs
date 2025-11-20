using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UnityDialogSys : MonoBehaviour, IDialog
{
    [SerializeField] private List<string> preBattleDialogue=new List<string>();
    [SerializeField] private List<string> postBattleVictoryDialogue=new List<string>();
    [SerializeField] private List<string> postBattleDefeatDialogue=new List<string>();

    [SerializeField] private List<string> preBattleCharacterNames = new List<string>();
    [SerializeField] private List<string> postBattleVictoryCharacterNames=new List<string>();
    [SerializeField] private List<string> postBattleDefeatCharacterNames=new List<string>();

    [SerializeField] private TextMeshProUGUI battleDialogue;
    [SerializeField] private TextMeshProUGUI battleDialogueCharacterNames;

    public SceneChanger sceneChanger;

    private int battleState;
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
        if (battleState==1)
        {
            if (postBattleVictoryDialogue.Count != postBattleVictoryCharacterNames.Count)
            {
                ManagerManager.Resolve<IGameLogger>().Error("The dialogue lines does not match the number of speak labels");
                return;
            }
            if (dialogueCount == postBattleVictoryDialogue.Count)
            {
                battleDialogue.transform.parent.gameObject.SetActive(false);
                return;
            }
            ManagerManager.Resolve<IGameLogger>().print(postBattleVictoryDialogue[dialogueCount]);
            battleDialogueCharacterNames.text = postBattleVictoryCharacterNames[dialogueCount];
            battleDialogue.text = postBattleVictoryDialogue[dialogueCount];
            dialogueCount++;
        }
        else if (battleState==2)
        {
            if (postBattleDefeatDialogue.Count != postBattleDefeatCharacterNames.Count)
            {
                ManagerManager.Resolve<IGameLogger>().Error("The dialogue lines does not match the number of speak labels");
                return;
            }
            if (dialogueCount == postBattleDefeatDialogue.Count)
            {
                battleDialogue.transform.parent.gameObject.SetActive(false);
                ManagerManager.Resolve<SceneChanger>().ChangeSceneToSpecificScene("DeathScreen");
                return;
            }
            ManagerManager.Resolve<IGameLogger>().print(postBattleDefeatDialogue[dialogueCount]);
            battleDialogueCharacterNames.text = postBattleDefeatCharacterNames[dialogueCount];
            battleDialogue.text = postBattleDefeatDialogue[dialogueCount];
            dialogueCount++;
        }
        else
        {
            if (preBattleDialogue.Count != preBattleCharacterNames.Count)
            {
                ManagerManager.Resolve<IGameLogger>().Error("The dialogue lines does not match the number of speak labels");
                return;
            }

            if (dialogueCount == preBattleDialogue.Count)
            {
                battleDialogue.transform.parent.gameObject.SetActive(false);
                return;
            }

            ManagerManager.Resolve<IGameLogger>().print(preBattleDialogue[dialogueCount]);
            battleDialogueCharacterNames.text = preBattleCharacterNames[dialogueCount];
            battleDialogue.text = preBattleDialogue[dialogueCount];
            dialogueCount++;
        }
    }

    public void PrepareBattleEndDialogue(int bS)
    {
        battleDialogue.transform.parent.gameObject.SetActive(true);
        battleState = bS;
        if (bS == 1)
        {
            battleDialogue.text = postBattleVictoryDialogue[0];
            battleDialogueCharacterNames.text = postBattleVictoryCharacterNames[0];
        }

        if (bS == 2)
        {
            battleDialogue.text = postBattleDefeatDialogue[0];
            battleDialogueCharacterNames.text = postBattleDefeatCharacterNames[0];
        }
        dialogueCount = 1;
    }

    public void HandleBattleEnd(LocationManager locationManager)
    {
        StartCoroutine(RunBattleEndSequence(locationManager));
    }

    private IEnumerator RunBattleEndSequence(LocationManager locationManager)
    {
        PrepareBattleEndDialogue(1);

        while (IsDialoguePlaying())
            yield return null;

        if (locationManager != null)
        {
            locationManager.SetupMapScene();
        }

        if (SceneManager.GetActiveScene().name.Equals("FinalBoss"))
        {
            SceneManager.LoadScene(14);
        }

        else
        {
            sceneChanger.ChangeSceneToSpecificScene("Map");
        }
    }

    public bool IsDialoguePlaying()
    {
        return battleDialogue.transform.parent.gameObject.activeSelf;
    }
}
