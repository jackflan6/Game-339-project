using System;
using UnityEngine;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    public static int cardID;
    public string Element;
    public int Damage;
    public int ShieldValue;
    public int BurnDamage;
    public int Heal;
    public bool DrawCard;
    public int ManaCost;
    //public Card(string element, int damage, int shieldValue, int burnDamage, int heal, int manaCost=1, bool drawCard=false)
    //{
    //    Element = element;
    //    Damage = damage;
    //    ShieldValue = shieldValue;
    //    BurnDamage = burnDamage;
    //    Heal = heal;
    //    DrawCard = drawCard;
    //    ManaCost = manaCost;
    //}



    //UnityEvent SelectedCard;
    bool hover;
    public Card origionalCard;
    void Start()
    {
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().onMouseMove += OnMouseMove;
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().onMousePress += OnMouseClick;
    }
    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().onMouseMove -= OnMouseMove;
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().onMousePress -= OnMouseClick;

    }

    public void OnMouseMove(Vector2 pos)
    {
        Vector3 worldPos = new Vector3(0, 0, transform.position.z) + (Vector3)((Vector2)Camera.main.ScreenToWorldPoint(pos));
        if (GetComponent<Collider2D>().bounds.Contains((Vector2)Camera.main.ScreenToWorldPoint(pos)))
        {
            hover = true;
        }else
        {
            hover = false;
        }
    }
    public void OnMouseClick(Vector2 pos)
    {
        if (hover)
        {
            ManagerManager.Resolve<TurnSystem>().SelectCardToPlay(origionalCard.GetComponent<Card>());
        }
    }
}
