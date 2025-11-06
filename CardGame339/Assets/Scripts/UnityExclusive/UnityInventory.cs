using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnityInventory : MonoBehaviour
{
    Inventory inventory;
    public List<GameObject> allCardsPrefabsInspector;
    public static List<GameObject> allCardsPrefabs;
    public GameObject inventorybutton;
    private void Awake()
    {
        allCardsPrefabs = allCardsPrefabsInspector;
    }
    void Start()
    { 
        DontDestroyOnLoad(gameObject);
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
        GameObject viewport = GameObject.FindGameObjectWithTag("inventory viewport");
        foreach (GameObject card in allCardsPrefabs)
        {
            GameObject button = Instantiate(inventorybutton, viewport.transform);
            button.GetComponent<Image>().sprite = card.GetComponent<SpriteRenderer>().sprite;



        }
    }


    public Lazy<Dictionary<Type, GameObject>> CardToPrefab = new Lazy<Dictionary<Type, GameObject>>(() => {
        Dictionary<Type, GameObject> dic = new Dictionary<Type, GameObject>();

        Dictionary<int, Type> idToTypes = ManagerManager.Resolve<CardManager>().GetAllCardIDs.Value;

        foreach (GameObject obj in allCardsPrefabs)
        {
            dic.TryAdd(idToTypes[obj.GetComponent<SelectableCard>().cardID], obj);
        }
        return dic;
    });

}
