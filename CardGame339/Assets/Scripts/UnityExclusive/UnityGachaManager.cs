using ConsoleApp1;
using UnityEngine;

public class UnityGachaManager : MonoBehaviour
{
    private GachaManager _gachaManager;
    public CardRoulette CardRoulette;
    public string selectedCardName;

    //private CurrencyManager _currencyManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gachaManager = ManagerManager.Resolve<GachaManager>();
       // _currencyManager = ManagerManager.Resolve<CurrencyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PullOneCard()
    {
        if (CurrencyManager.currencyAmount.Value >= 5)
        {
            CurrencyManager.currencyAmount.Value -= 5;
            //pull card and put in inventory
            Card selectedCard = _gachaManager.Pull(_gachaManager.gachaItems);
            selectedCardName = selectedCard.Name;
            Debug.Log("List Count:" + CardRoulette.cardSprites.Count);
            CardRoulette.Spin(selectedCardName);
            Debug.Log("Received card: " + selectedCard);
        }
    }

    public void PullPackOfCards()
    {
        if (CurrencyManager.currencyAmount.Value >= 15)
        {
            CurrencyManager.currencyAmount.Value -= 15;
            Debug.Log("Received cards: " +_gachaManager.PullFiveTimes(_gachaManager.gachaItems));
        }
    }
}
