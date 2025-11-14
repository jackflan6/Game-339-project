using ConsoleApp1;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Currency : MonoBehaviour
{
    CurrencyManager currencyManager;
    void Start()
    {
        currencyManager = ManagerManager.Resolve<CurrencyManager>();
        currencyManager.currencyAmount.ValueChanged += UpdateValue;
        UpdateValue(currencyManager.currencyAmount.Value);
    }
    private void OnDestroy()
    {
        currencyManager.currencyAmount.ValueChanged -= UpdateValue;
    }

    public void UpdateValue(int val)
    {
        GameObject.FindGameObjectWithTag("UICurrency").GetComponent<TextMeshProUGUI>().text = "Gold: " + val.ToString();
    }

}
