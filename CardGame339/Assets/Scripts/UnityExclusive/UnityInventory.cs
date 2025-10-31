using Unity.VisualScripting;
using UnityEngine;

public class UnityInventory : MonoBehaviour
{
    Inventory inventory;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AddCardToInventory(Card card)
    {
        inventory.AddCardsInInventory(card);
    }
    
    

}
