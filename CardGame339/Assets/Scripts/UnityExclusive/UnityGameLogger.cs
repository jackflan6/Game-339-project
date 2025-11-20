using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class UnityGameLogger : IGameLogger
{
    public void Info(string message)
    {
        Debug.Log(message);
    }

    public void Warning(string message)
    {
        Debug.Log(message);
    }

    public void Error(string message)
    {
        throw new Exception(message);
    }
    public void print(string message)
    {
        Debug.Log(message);
    }
}
