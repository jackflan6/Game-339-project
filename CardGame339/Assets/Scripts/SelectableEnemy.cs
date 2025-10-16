using System;
using UnityEngine;

public class SelectableEnemy : MonoBehaviour
{

    //UnityEvent SelectedCard;
    bool hover;

    public int enemyID;
    public Enemy origionalEnemy;
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
        } else
        {
            hover = false;
        }
    }
    public void OnMouseClick(Vector2 pos)
    {
        if (hover)
        {
           ManagerManager.Resolve<TurnSystem>().SelectEnemyToAttack(origionalEnemy.GetComponent<Enemy>());
        }
    }
}
