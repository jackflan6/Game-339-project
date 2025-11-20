using ConsoleApp1;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MaxHP : MonoBehaviour
{
    CurrencyManager currencyManager;
    void Start()
    {
        currencyManager = ManagerManager.Resolve<CurrencyManager>();
        currencyManager.maxPlayerHP.ValueChanged += UpdateValue;
        UpdateValue(currencyManager.maxPlayerHP.Value);
    }
    private void OnDestroy()
    {
        currencyManager.maxPlayerHP.ValueChanged -= UpdateValue;
    }

    public void UpdateValue(int val)
    {
        GameObject.FindGameObjectWithTag("UIMaxHP").GetComponent<TextMeshProUGUI>().text = "Max HP: " + val.ToString();
    }

}
