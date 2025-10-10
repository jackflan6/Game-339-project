using NUnit.Framework;
using System;
using System.Transactions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManagerManager : MonoBehaviour
{
    [SerializeField]
    public List<IManager> managers;

    private void Start()
    {
        foreach (IManager m in managers)
        {
            m.start();
        }
    }
    private void Awake()
    {
        foreach (IManager m in managers)
        {
            m.awake();
        }
    }
    private void Update()
    {
        foreach (IManager m in managers)
        {
            m.update();
        }
    }
}
