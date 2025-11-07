using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject card;
    public Card origionalCard;
    public bool selected;
    public Color selectedColor;
    private Color origionalColor;

    private void Start()
    {
        origionalColor = GetComponent<Image>().color;
        if(selected)
        {
            GetComponent<Image>().color = selectedColor;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnClick()
    {
        if (selected)
        {
            selected = false;
            GetComponent<Image>().color = origionalColor;
            GameObject.FindGameObjectWithTag("inventory").GetComponent<UnityInventory>().RemoveCardToInventory(origionalCard);
        } else
        {
            selected = true;
            GetComponent<Image>().color = selectedColor;
            GameObject.FindGameObjectWithTag("inventory").GetComponent<UnityInventory>().AddCardToInventory(origionalCard);
        }
    }


}
