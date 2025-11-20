using System;
using UnityEngine;

public class SelectableEnemy : MonoBehaviour
{

    //UnityEvent SelectedCard;
    bool hover;
    [HideInInspector]
    public int enemyID;
    public Enemy origionalEnemy;
    public Vector2 EnemyPosition;
    public float acceleration = 10;
    private Color defaultColor;
    void Start()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().onMouseMove += OnMouseMove;
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().onMousePress += OnMouseClick;
        defaultColor = this.GetComponent<SpriteRenderer>().color;
    }
    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().onMouseMove -= OnMouseMove;
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().onMousePress -= OnMouseClick;

    }
    private float speed;
    private void Update()
    {
        //if ((EnemyPosition - (Vector2)transform.position).magnitude < speed)
        //{
        //    speed = ((Vector2)transform.position + EnemyPosition).magnitude / (speed * Time.deltaTime);
        //} else
        //{
        //    speed += acceleration * Time.deltaTime;
        //}
        //Vector2 dir = EnemyPosition - (Vector2)transform.position;
        //transform.position =dir * speed * Time.deltaTime;

       transform.position = EnemyPosition;
    }
    public void OnMouseMove(Vector2 pos)
    {
        Vector3 worldPos = new Vector3(0, 0, transform.position.z) + (Vector3)((Vector2)Camera.main.ScreenToWorldPoint(pos));
        if (GetComponent<Collider2D>().bounds.Contains((Vector2)Camera.main.ScreenToWorldPoint(pos)))
        {
            hover = true;
            GetComponent<SpriteRenderer>().color = Color.yellow;
        } else
        {
            hover = false;
            GetComponent<SpriteRenderer>().color = defaultColor;
        }
    }
    public void OnMouseClick(Vector2 pos)
    {
        if (hover)
        {
            GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioPlayer>().playSoundEffect();
           ManagerManager.Resolve<TurnSystem>().SelectEnemyToAttack(origionalEnemy);
        }
    }
}
