using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnityInventory : MonoBehaviour
{
    Inventory inventory;
    public List<GameObject> allCardsPrefabs;
    public GameObject inventorybutton;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        reloadOptions();
    }

    public void AddCardToInventory(Card card)
    {
        inventory.AddCardsInInventory(card);
    }

    public List<GameObject> buttons;
    public void reloadOptions()
    {
        GameObject viewport = GameObject.FindGameObjectWithTag("inventory viewport");
        foreach (GameObject card in allCardsPrefabs)
        {
            GameObject button = Instantiate(inventorybutton,viewport.transform);
            button.GetComponent<Image>().sprite = card.GetComponent<SpriteRenderer>().sprite;
        }
    }

}
