using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTextDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string descriptionToBeDisplayed;

    private Color normCol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ManagerManager.Resolve<IGameLogger>().print(descriptionToBeDisplayed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject.FindGameObjectWithTag("CardInfoPanel").GetComponent<TextMeshPro>().alpha=1;
        GameObject.FindGameObjectWithTag("CardInfoPanel").GetComponent<TextMeshPro>().text = descriptionToBeDisplayed;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject.FindGameObjectWithTag("CardInfoPanel").GetComponent<TextMeshPro>().alpha=0;
    }
}
