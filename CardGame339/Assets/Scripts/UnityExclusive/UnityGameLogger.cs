using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class UnityGameLogger : MonoBehaviour, IGameLogger
{
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("GlobalResolver").GetComponent<GlobalResolver>().loaded)
        {
            Destroy(gameObject);
        }
    }
    public void Info(string message)
    {
        print(message);
    }

    public void Warning(string message)
    {
        print(message);
    }

    public void Error(string message)
    {
        print(message);
    }
    public void print(string message)
    {
        Debug.Log(message);
    }
}
