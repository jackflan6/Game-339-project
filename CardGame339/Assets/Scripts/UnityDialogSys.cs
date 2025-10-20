using UnityEngine;

public class UnityDialogSys : MonoBehaviour, IDialog
{
    public void EnemyTalk(Enemy enemy, string message)
    {
        GameObject enemyObj = GameObjectManager.allCreatedEnemys[enemy];
        if (enemyObj.GetComponent<DialogueDisplayer>() == null)
        {
            enemyObj.AddComponent<DialogueDisplayer>();
        }
        enemyObj.GetComponent<DialogueDisplayer>().DisplayCharacterDialogue(message,enemyObj);
    }
}
