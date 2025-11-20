using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnityInventory : MonoBehaviour
{
    Inventory inventory;
    public List<GameObject> allCardsPrefabsInspector;
    public static List<GameObject> allCardsPrefabs;
    public GameObject inventorybutton;
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("inventory").Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        ManagerManager.registerPersistentDependency(() => new Inventory());
        allCardsPrefabs = allCardsPrefabsInspector;
    }
    void Start()
    {
        inventory = ManagerManager.Resolve<Inventory>();
        reloadOptions();
    }

    public void AddCardToInventory(Card card)
    {
        inventory.AddCardsInInventory(card);
    }

    public void RemoveCardToInventory(Card card)
    {
        inventory.RemoveCardsInInventory(card);
    }

    public List<GameObject> buttons;
    public void reloadOptions()//this will change when implemented with gatcha system
    {
        UnloadButtons();
        GameObject viewport = GameObject.FindGameObjectWithTag("inventory viewport");
        foreach (Card card in inventory.GetAllCardsUnlocked())
        {
            GameObject button = Instantiate(inventorybutton, viewport.transform);
            button.GetComponent<Image>().sprite = CardToPrefab.Value[card.GetType()].GetComponent<SpriteRenderer>().sprite;
            button.GetComponent<InventoryButton>().origionalCard = card;
            if (inventory.GetAllCardsInInventory().Contains(card))
            {
                button.GetComponent<InventoryButton>().selected = true;
            }
            buttons.Add(button);
        }
    }
    public void UnloadButtons()
    {
        foreach(GameObject g in buttons)
        {
            Destroy(g);
        }
        buttons = new List<GameObject>();
    }


    public Lazy<Dictionary<Type, GameObject>> CardToPrefab = new Lazy<Dictionary<Type, GameObject>>(() => {
        Dictionary<Type, GameObject> dic = new Dictionary<Type, GameObject>();

        Dictionary<int, Type> idToTypes = ManagerManager.Resolve<Inventory>().GetAllCardIDs.Value;

        foreach (GameObject obj in allCardsPrefabs)
        {
            dic.TryAdd(idToTypes[obj.GetComponent<SelectableCard>().cardID], obj);
        }
        return dic;
    });

}
