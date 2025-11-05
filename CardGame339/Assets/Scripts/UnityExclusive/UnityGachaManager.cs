using ConsoleApp1;
using UnityEngine;

public class UnityGachaManager : MonoBehaviour
{
    private GachaManager _gachaManager;

    private CurrencyManager _currencyManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gachaManager = ManagerManager.Resolve<GachaManager>();
        _currencyManager = ManagerManager.Resolve<CurrencyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PullOneCard()
    {
        if (_currencyManager.currencyAmount.Value >= 5)
        {
            _currencyManager.currencyAmount.Value -= 5;
            //pull card and put in inventory
            Debug.Log("Received card: " + _gachaManager.Pull(_gachaManager.gachaItems));
        }
    }

    public void PullPackOfCards()
    {
        if (_currencyManager.currencyAmount.Value >= 15)
        {
            Debug.Log("Received cards: " +_gachaManager.PullFiveTimes(_gachaManager.PullFiveTimes(_gachaManager.gachaItems)));
        }
    }
}
