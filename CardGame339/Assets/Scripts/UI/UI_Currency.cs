using ConsoleApp1;
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
        GetComponent<Text>().text = "Currency: " + val.ToString();
    }

}
