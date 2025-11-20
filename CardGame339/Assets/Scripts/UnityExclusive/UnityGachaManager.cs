using System.Collections;
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
            ManagerManager.Resolve<IGameLogger>().print("List Count:" + CardRoulette.cardSprites.Count);
            CardRoulette.Spin(selectedCard, CardRoulette.SlotImages[0], CardRoulette.Panels[0]);
            ManagerManager.Resolve<IGameLogger>().print("Received card: " + selectedCard);
            ManagerManager.Resolve<Inventory>().unlockCard(selectedCard);
        }
        else if (currencyManager.maxPlayerHP >= 2)
        {
            currencyManager.maxPlayerHP.Value -= 2;
            //pull card and put in inventory
            Card selectedCard = _gachaManager.Pull(_gachaManager.gachaItems);
            selectedCardName = selectedCard.Name;
            ManagerManager.Resolve<IGameLogger>().print("List Count:" + CardRoulette.cardSprites.Count);
            CardRoulette.Spin(selectedCard, CardRoulette.SlotImages[0], CardRoulette.Panels[0]);
            ManagerManager.Resolve<IGameLogger>().print("Received card: " + selectedCard);
            ManagerManager.Resolve<Inventory>().unlockCard(selectedCard);
        }
    }

    public void PullPackOfCards()
    {
        if (currencyManager.currencyAmount.Value >= 0)
        {
            currencyManager.currencyAmount.Value -= 0;
            List<Card> receivedCards = _gachaManager.PullPack(_gachaManager.gachaItems);
            foreach (Card card in receivedCards)
            {
                ManagerManager.Resolve<IGameLogger>().print("Received card: " + card);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
            }
        }
    }

    public void PullFirePack()
    {
        StartCoroutine(FireCardsCoroutine(0.2f));
    }
    public void PullEarthPAck()
    {
        StartCoroutine(EarthCardsCoroutine(0.2f));
    }

    public void PullWindPack()
    {
        StartCoroutine(WindCardsCoroutine(0.2f));
    }

    public void PullLightningPack()
    {
        StartCoroutine(LightningCardsCoroutine(0.2f));
    }

    public void PullOmniPack()
    {
        StartCoroutine(OmniCardsCoroutine(0.2f));
    }

    public void PullLegendaryPack()
    {
        StartCoroutine(LegendaryCardsCoroutine(0.2f));
    }
    
    public IEnumerator FireCardsCoroutine(float Delay)
    {
        if (currencyManager.currencyAmount.Value >= 15)
        {
            currencyManager.currencyAmount.Value -= 15;
            List<Card> receivedCards = _gachaManager.PullFireFiveTimes(_gachaManager.gachaItems);
            int slotImageNumber = 1;
            foreach (Card card in receivedCards)
            {
                ManagerManager.Resolve<IGameLogger>().print("Received card: " + card);
                selectedCardName = card.Name;
                CardRoulette.Spin(card, CardRoulette.SlotImages[slotImageNumber], CardRoulette.Panels[2]);
                ManagerManager.Resolve<IGameLogger>().print("spun");
                ManagerManager.Resolve<Inventory>().unlockCard(card);
                yield return new WaitForSeconds(Delay);
                slotImageNumber ++;
            }
        }
        else if (currencyManager.maxPlayerHP.Value > 5)
        {
            currencyManager.maxPlayerHP.Value -= 5;
            List<Card> receivedCards = _gachaManager.PullFireFiveTimes(_gachaManager.gachaItems);
            int slotImageNumber = 1;
            foreach (Card card in receivedCards)
            {
                ManagerManager.Resolve<IGameLogger>().print("Received card: " + card);
                selectedCardName = card.Name;
                CardRoulette.Spin(card, CardRoulette.SlotImages[slotImageNumber], CardRoulette.Panels[2]);
                ManagerManager.Resolve<IGameLogger>().print("spun");
                ManagerManager.Resolve<Inventory>().unlockCard(card);
                yield return new WaitForSeconds(Delay);
                slotImageNumber ++;
            }
        }
    }
    
    public IEnumerator EarthCardsCoroutine(float Delay)
    {
        if (currencyManager.currencyAmount.Value >= 15)
        {
            currencyManager.currencyAmount.Value -= 15;
            List<Card> receivedCards = _gachaManager.PullEarthFiveTimes(_gachaManager.gachaItems);
            int slotImageNumber = 1;
            foreach (Card card in receivedCards)
            {
                ManagerManager.Resolve<IGameLogger>().print("Received card: " + card);
                selectedCardName = card.Name;
                CardRoulette.Spin(card, CardRoulette.SlotImages[slotImageNumber], CardRoulette.Panels[1]);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
                yield return new WaitForSeconds(Delay);
                slotImageNumber ++;
            }
        }
        
        else if (currencyManager.maxPlayerHP.Value > 5)
        {
            currencyManager.maxPlayerHP.Value -= 5;
            List<Card> receivedCards = _gachaManager.PullEarthFiveTimes(_gachaManager.gachaItems);
            int slotImageNumber = 1;
            foreach (Card card in receivedCards)
            {
                ManagerManager.Resolve<IGameLogger>().print("Received card: " + card);
                selectedCardName = card.Name;
                CardRoulette.Spin(card, CardRoulette.SlotImages[slotImageNumber], CardRoulette.Panels[1]);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
                yield return new WaitForSeconds(Delay);
                slotImageNumber ++;
            }
        }
    }
    
    public IEnumerator WindCardsCoroutine(float Delay)
    {
        if (currencyManager.currencyAmount.Value >= 15)
        {
            currencyManager.currencyAmount.Value -= 15;
            List<Card> receivedCards = _gachaManager.PullWindFiveTimes(_gachaManager.gachaItems);
            int slotImageNumber = 1;
            foreach (Card card in receivedCards)
            {
                ManagerManager.Resolve<IGameLogger>().print("Received card: " + card);
                selectedCardName = card.Name;
                CardRoulette.Spin(card, CardRoulette.SlotImages[slotImageNumber], CardRoulette.Panels[6]);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
                yield return new WaitForSeconds(Delay);
                slotImageNumber ++;
            }
        }
        
        else if (currencyManager.maxPlayerHP.Value > 5)
        {
            currencyManager.maxPlayerHP.Value -= 5;
            List<Card> receivedCards = _gachaManager.PullWindFiveTimes(_gachaManager.gachaItems);
            int slotImageNumber = 1;
            foreach (Card card in receivedCards)
            {
                ManagerManager.Resolve<IGameLogger>().print("Received card: " + card);
                selectedCardName = card.Name;
                CardRoulette.Spin(card, CardRoulette.SlotImages[slotImageNumber], CardRoulette.Panels[6]);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
                yield return new WaitForSeconds(Delay);
                slotImageNumber ++;
            }
        }
    }
    
    public IEnumerator LightningCardsCoroutine(float Delay)
    {
        if (currencyManager.currencyAmount.Value >= 15)
        {
            currencyManager.currencyAmount.Value -= 15;
            List<Card> receivedCards = _gachaManager.PullLightningFiveTimes(_gachaManager.gachaItems);
            int slotImageNumber = 1;
            foreach (Card card in receivedCards)
            {
                ManagerManager.Resolve<IGameLogger>().print("Received card: " + card);
                selectedCardName = card.Name;
                CardRoulette.Spin(card, CardRoulette.SlotImages[slotImageNumber], CardRoulette.Panels[5]);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
                yield return new WaitForSeconds(Delay);
                slotImageNumber ++;
            }
        }
        
        else if (currencyManager.maxPlayerHP.Value > 5)
        {
            currencyManager.maxPlayerHP.Value -= 5;
            List<Card> receivedCards = _gachaManager.PullLightningFiveTimes(_gachaManager.gachaItems);
            int slotImageNumber = 1;
            foreach (Card card in receivedCards)
            {
                ManagerManager.Resolve<IGameLogger>().print("Received card: " + card);
                selectedCardName = card.Name;
                CardRoulette.Spin(card, CardRoulette.SlotImages[slotImageNumber], CardRoulette.Panels[5]);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
                yield return new WaitForSeconds(Delay);
                slotImageNumber ++;
            }
        }
    }
    
    public IEnumerator OmniCardsCoroutine(float Delay)
    {
        if (currencyManager.currencyAmount.Value >= 15)
        {
            currencyManager.currencyAmount.Value -= 15;
            List<Card> receivedCards = _gachaManager.PullOmniFiveTimes(_gachaManager.gachaItems);
            int slotImageNumber = 1;
            foreach (Card card in receivedCards)
            {
                ManagerManager.Resolve<IGameLogger>().print("Received card: " + card);
                selectedCardName = card.Name;
                CardRoulette.Spin(card, CardRoulette.SlotImages[slotImageNumber], CardRoulette.Panels[3]);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
                yield return new WaitForSeconds(Delay);
                slotImageNumber ++;
            }
        }
        
        else if (currencyManager.maxPlayerHP.Value > 5)
        {
            currencyManager.maxPlayerHP.Value -= 5;
            List<Card> receivedCards = _gachaManager.PullOmniFiveTimes(_gachaManager.gachaItems);
            int slotImageNumber = 1;
            foreach (Card card in receivedCards)
            {
                ManagerManager.Resolve<IGameLogger>().print("Received card: " + card);
                selectedCardName = card.Name;
                CardRoulette.Spin(card, CardRoulette.SlotImages[slotImageNumber], CardRoulette.Panels[3]);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
                yield return new WaitForSeconds(Delay);
                slotImageNumber ++;
            }
        }
    }
    
    public IEnumerator LegendaryCardsCoroutine(float Delay)
    {
        if (currencyManager.currencyAmount.Value >= 0)
        {
            currencyManager.currencyAmount.Value -= 0;
            List<Card> receivedCards = _gachaManager.PullLegendaryFiveTimes(_gachaManager.gachaItems);
            int slotImageNumber = 1;
            foreach (Card card in receivedCards)
            {
                ManagerManager.Resolve<IGameLogger>().print("Received card: " + card);
                selectedCardName = card.Name;
                CardRoulette.Spin(card, CardRoulette.SlotImages[slotImageNumber], CardRoulette.Panels[4]);
                ManagerManager.Resolve<Inventory>().unlockCard(card);
                yield return new WaitForSeconds(Delay);
                slotImageNumber ++;
            }
        }
    }
    
}
