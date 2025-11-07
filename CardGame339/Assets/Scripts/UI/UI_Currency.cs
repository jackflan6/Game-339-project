using ConsoleApp1;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Currency : MonoBehaviour
{
    void Start()
    {
        CurrencyManager.currencyAmount.ValueChanged += UpdateValue;
        UpdateValue(CurrencyManager.currencyAmount.Value);
    }
    private void OnDestroy()
    {
        CurrencyManager.currencyAmount.ValueChanged -= UpdateValue;
    }

    public void UpdateValue(int val)
    {
        GameObject.FindGameObjectWithTag("UICurrency").GetComponent<TextMeshProUGUI>().text = "Gold: " + val.ToString();
    }

}
