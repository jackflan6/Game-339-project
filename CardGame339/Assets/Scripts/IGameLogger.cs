using System;
using Unity;
using UnityEngine;

public interface IGameLogger
{
    void Info(string message);
    void Warning(string message);
    void Error(string message);
    void print(string message);
    void Destroy(object obj);
    GameObject Instantiate(GameObject obj, Vector3 pos, Quaternion rot);
}