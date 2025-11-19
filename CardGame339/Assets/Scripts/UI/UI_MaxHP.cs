using System;
using ConsoleApp1;
using UnityEngine;
using UnityEngine.UI;

public class UI_MaxHP: MonoBehaviour
{
    void Start()
    {
        ManagerManager.Resolve<CurrencyManager>().maxPlayerHP.ValueChanged += UpdateValue;
        UpdateValue(ManagerManager.Resolve<CurrencyManager>().maxPlayerHP.Value);
    }

    public void UpdateValue(int val)
    {
        if(gameObject!=null)
        {
            GetComponent<Text>().text = "Max HP: " + val.ToString();
        }
    }

    public void OnDestroy()
    {
        ManagerManager.Resolve<CurrencyManager>().maxPlayerHP.ValueChanged -= UpdateValue;
    }
}
