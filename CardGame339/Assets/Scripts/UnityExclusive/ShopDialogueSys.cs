using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopDialogueSys : MonoBehaviour, IDialog
{
    [SerializeField] private List<string> shopEnterDialogue=new List<string>();
    [SerializeField] private List<string> shopEnterDialogueCharacterNames = new List<string>();
    
    [SerializeField] private TextMeshProUGUI shopDialogue;
    [SerializeField] private TextMeshProUGUI shopDialogueCharacterNames;
    private GlobalResolver _globalResolver;

    private int dialogueCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _globalResolver = GameObject.FindGameObjectWithTag("GlobalResolver").GetComponent<GlobalResolver>();
        if (shopDialogue != null && shopEnterDialogue.Count > 0)
        {
            shopDialogue.text = shopEnterDialogue[0];
        }
        
        if (shopDialogueCharacterNames != null && shopEnterDialogueCharacterNames.Count > 0)
        {
            shopDialogueCharacterNames.text = shopEnterDialogueCharacterNames[0];
        }

        if (_globalResolver.hasShownShopDialogue)
        {
            shopDialogue.transform.parent.gameObject.SetActive(false);
        }
        dialogueCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextDialogue()
    {
        if (dialogueCount == shopEnterDialogue.Count)
        {
            shopDialogue.transform.parent.gameObject.SetActive(false);
            _globalResolver.hasShownShopDialogue = true;
            return;
        }
        ManagerManager.Resolve<IGameLogger>().print(shopEnterDialogue[dialogueCount]);
        shopDialogueCharacterNames.text = shopEnterDialogueCharacterNames[dialogueCount];
        shopDialogue.text = shopEnterDialogue[dialogueCount];
        dialogueCount++;
    }

    public void EnemyTalk(Enemy enemy, string message)
    {
        throw new System.NotImplementedException();
    }
}
