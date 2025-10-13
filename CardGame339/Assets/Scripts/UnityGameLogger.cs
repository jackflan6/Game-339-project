using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class UnityGameLogger : MonoBehaviour, IGameLogger
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("ServiceResolver").GetComponent<ServiceResolver>().logger = this;
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
    public void Destroy(object obj) 
    {
        GameObject.Destroy((GameObject)obj);
    }
    public GameObject Instantiate(GameObject obj, Vector3 pos, Quaternion rot)
    {
        return GameObject.Instantiate(obj, pos, rot);
    }
}
