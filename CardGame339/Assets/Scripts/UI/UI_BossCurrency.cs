using ConsoleApp1;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_BossCurrency : MonoBehaviour
{
    CurrencyManager currencyManager;
    void Start()
    {
        currencyManager = ManagerManager.Resolve<CurrencyManager>();
        currencyManager.bossCurrencyAmount.ValueChanged += UpdateValue;
        UpdateValue(currencyManager.bossCurrencyAmount.Value);
    }
    private void OnDestroy()
    {
        currencyManager.bossCurrencyAmount.ValueChanged -= UpdateValue;
    }

    public void UpdateValue(int val)
    {
        currencyManager.logger.print("Boss dropped " + val);
        GameObject.FindGameObjectWithTag("UIBossCurrency").GetComponent<TextMeshProUGUI>().text = "Cores: " + val.ToString();
    }

}
