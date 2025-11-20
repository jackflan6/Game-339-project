using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    //UnityEvent SelectedCard;
    bool hover;
    [HideInInspector]
    public int cardID;
    /*    public string Element;
        public int Damage;
        public int ShieldValue;
        public int BurnDamage;
        public int Heal;
        public int ManaCost;*/
    public Card origionalCard;
    public Vector2 cardPosition;
    public float acceleration = 10;
    Color normCol = Color.white;
    public Color originalCol;
    private float normscale;
    void Start()
    {
        normscale = transform.localScale.x;
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().onMousePress += OnMouseClick;
    }
    private void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("UIManager") != null) { 
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().onMousePress -= OnMouseClick;
        }
    }
    private float speed;
    private void Update()
    {
        
        if ((cardPosition - (Vector2)transform.position).magnitude < speed)
        {
            speed = (cardPosition - (Vector2)transform.position).magnitude / (speed) * Time.deltaTime;
        } else
        {
            speed += acceleration * Time.deltaTime;
        }
        Vector2 dir = cardPosition - (Vector2)transform.position;
        transform.position +=(Vector3) dir * speed;

        //transform.position = cardPosition;
    }
    public void OnMouseClick(Vector2 pos)
    {
        if (hover)
        {
           ManagerManager.Resolve<TurnSystem>().SelectCardToPlay(origionalCard);
            normCol = Color.orange;
        }else
        {
            normCol = originalCol;

        }
        GetComponent<SpriteRenderer>().color = normCol;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
        if (normCol != Color.orange) { 
        GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        transform.localScale = new Vector3(normscale*1.5f, normscale*1.5f, 1);
        GameObject.FindGameObjectWithTag("CardInfoPanel").GetComponent<TextMeshPro>().alpha=1;
        GameObject.FindGameObjectWithTag("CardInfoPanel").GetComponent<TextMeshPro>().text =
            origionalCard.Description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
        GetComponent<SpriteRenderer>().color = normCol;
        transform.localScale = new Vector3(normscale, normscale, 1);
        GameObject.FindGameObjectWithTag("CardInfoPanel").GetComponent<TextMeshPro>().alpha=0;
    }
}
