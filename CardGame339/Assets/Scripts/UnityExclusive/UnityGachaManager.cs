using ConsoleApp1;
using UnityEngine;

public class UnityGachaManager : MonoBehaviour
{
    private GachaManager _gachaManager;
    public CardRoulette CardRoulette;
    public string selectedCardName;

    private CurrencyManager currencyManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gachaManager = ManagerManager.Resolve<GachaManager>();
       currencyManager = ManagerManager.Resolve<CurrencyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PullOneCard()
    {
        if (currencyManager.currencyAmount.Value >= 5)
        {
            currencyManager.currencyAmount.Value -= 5;
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
        if (currencyManager.currencyAmount.Value >= 15)
        {
            currencyManager.currencyAmount.Value -= 15;
            Debug.Log("Received cards: " +_gachaManager.PullFiveTimes(_gachaManager.gachaItems));
        }
    }
}
