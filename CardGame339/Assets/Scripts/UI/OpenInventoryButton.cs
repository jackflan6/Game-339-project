using UnityEngine;

public class OpenInventoryButton : MonoBehaviour
{
   public void onClick()
    {
        GameObject.FindGameObjectWithTag("inventory").GetComponent<UnityInventory>().reloadOptions();
    }
    public void OffInventory()
    {
        GameObject.FindGameObjectWithTag("inventory").GetComponent<UnityInventory>().UnloadButtons();

    }
}
