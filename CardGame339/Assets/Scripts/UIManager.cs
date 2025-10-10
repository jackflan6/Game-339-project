using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public event Action<Vector2> onMouseMove;
    public event Action<Vector2> onMousePress;
    public Vector2 mousepos;

    // Update is called once per frame
    void Update()
    {
        if (mousepos != Mouse.current.position.value && onMouseMove != null)
        {
            mousepos = Mouse.current.position.value;
            onMouseMove.Invoke(mousepos);
        }
        if (Mouse.current.press.value >0 && mousepos != null)
        {
            Debug.Log(onMouseMove.GetInvocationList().Length);
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
