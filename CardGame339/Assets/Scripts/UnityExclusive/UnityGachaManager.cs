using System.Collections.Generic;
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
            ManagerManager.Resolve<Inventory>().unlockCard(selectedCard);
        }
    }

    public void PullPackOfCards()
    {
        if (currencyManager.currencyAmount.Value >= 15)
        {
            currencyManager.currencyAmount.Value -= 15;
            List<Card> receivedCards = _gachaManager.PullPack(_gachaManager.gachaItems);
            foreach (Card card in receivedCards)
            {
                Debug.Log("Received card: " + card);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
            }
        }
    }

    public void PullPackOfFireCards()
    {
        if (currencyManager.currencyAmount.Value >= 15)
        {
            currencyManager.currencyAmount.Value -= 15;
            List<Card> receivedCards = _gachaManager.PullFireFiveTimes(_gachaManager.gachaItems);
            foreach (Card card in receivedCards)
            {
                Debug.Log("Received card: " + card);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
            }
        }
    }
    
    public void PullPackOfEarthCards()
    {
        if (currencyManager.currencyAmount.Value >= 15)
        {
            currencyManager.currencyAmount.Value -= 15;
            List<Card> receivedCards = _gachaManager.PullFiveEarthTimes(_gachaManager.gachaItems);
            foreach (Card card in receivedCards)
            {
                Debug.Log("Received card: " + card);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
            }
        }
    }
    
    public void PullPackOfWindCards()
    {
        if (currencyManager.currencyAmount.Value >= 15)
        {
            currencyManager.currencyAmount.Value -= 15;
            List<Card> receivedCards = _gachaManager.PullWindFiveTimes(_gachaManager.gachaItems);
            foreach (Card card in receivedCards)
            {
                Debug.Log("Received card: " + card);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
            }
        }
    }
    
    public void PullPackOfLightningCards()
    {
        if (currencyManager.currencyAmount.Value >= 15)
        {
            currencyManager.currencyAmount.Value -= 15;
            List<Card> receivedCards = _gachaManager.PullLightningFiveTimes(_gachaManager.gachaItems);
            foreach (Card card in receivedCards)
            {
                Debug.Log("Received card: " + card);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
            }
        }
    }
    
    public void PullPackOfOmniCards()
    {
        if (currencyManager.currencyAmount.Value >= 15)
        {
            currencyManager.currencyAmount.Value -= 15;
            List<Card> receivedCards = _gachaManager.PullOmniFiveTimes(_gachaManager.gachaItems);
            foreach (Card card in receivedCards)
            {
                Debug.Log("Received card: " + card);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
            }
        }
    }
    
    public void PullPackOfLegendaryCards()
    {
        if (currencyManager.currencyAmount.Value >= 1)
        {
            currencyManager.currencyAmount.Value -= 1;
            List<Card> receivedCards = _gachaManager.PullLegendaryFiveTimes(_gachaManager.gachaItems);
            foreach (Card card in receivedCards)
            {
                Debug.Log("Received card: " + card);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
            }
        }
    }
    
}
