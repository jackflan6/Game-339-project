using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public event Action<Vector2> onMouseMove;
    public event Action<Vector2> onMousePress;
    public Vector2 mousepos;

    public Text shieldText;
    public Text playerHP;
    public Text manaText;



    private void Awake()
    {
        GameObject.FindGameObjectWithTag("ServiceResolver").GetComponent<ServiceResolver>().UImanager = this;
    }



    void Update()
    {
        if (mousepos != Mouse.current.position.value && onMouseMove != null && onMouseMove != null)
        {
            mousepos = Mouse.current.position.value;
            onMouseMove.Invoke(mousepos);
        }
        if (Mouse.current.press.value >0 && mousepos != null && onMousePress != null)
        {
            onMousePress.Invoke(mousepos);
        }
    }
    public void subToOnMouseMove(Action<Vector2> action)
    {
        Debug.Log("what");
        onMouseMove += action;
    }
    public void subToOnMousePress(Action<Vector2> action)
    {
        Debug.Log("what");
        onMousePress += action;
    }
}
