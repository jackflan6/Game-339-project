using System;
using UnityEngine;

public class SelectableCard : MonoBehaviour
{

    //UnityEvent SelectedCard;
    bool hover;
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
    private float speed;
    private void Update()
    {
        //if ((cardPosition - (Vector2)transform.position).magnitude < speed)
        //{
        //    speed = ((Vector2)transform.position + cardPosition).magnitude/(speed * Time.deltaTime);
        //} else
        //{
        //    speed += acceleration * Time.deltaTime;
        //}
        //Vector2 dir = cardPosition - (Vector2)transform.position;
        //transform.position =dir * speed * Time.deltaTime;

        transform.position = cardPosition;
    }
    public void OnMouseMove(Vector2 pos)
    {
        Vector3 worldPos = new Vector3(0, 0, transform.position.z) + (Vector3)((Vector2)Camera.main.ScreenToWorldPoint(pos));
        if (GetComponent<Collider2D>().bounds.Contains((Vector2)Camera.main.ScreenToWorldPoint(pos)))
        {
            hover = true;
        } else
        {
            hover = false;
        }
    }
    public void OnMouseClick(Vector2 pos)
    {
        if (hover)
        {
           ManagerManager.Resolve<TurnSystem>().SelectCardToPlay(origionalCard);
        }
    }
}
