using ConsoleApp1;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Currency : MonoBehaviour
{
    void Start()
    {
        ManagerManager.Resolve<CurrencyManager>().currencyAmount.ValueChanged += UpdateValue;
        UpdateValue(ManagerManager.Resolve<CurrencyManager>().currencyAmount.Value);
    }

    public void UpdateValue(int val)
    {
        GameObject.FindGameObjectWithTag("UICurrency").GetComponent<TextMeshProUGUI>().text = "Gold: " + val.ToString();
    }

}
