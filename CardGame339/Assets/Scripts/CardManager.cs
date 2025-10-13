using System.Collections.Generic;
using UnityEngine;

public class CardManager : IManager
{
    public List<Card> Deck = new List<Card>();
    public List<Card> Hand = new List<Card>();

    public List<Card> DiscardPile = new List<Card>();

    public List<Card> AllCards = ManagerManager.Resolve<List<Card>>();
    public CombatSystem CombatSystem = ManagerManager.Resolve<CombatSystem>();

    public int startingHandSize = ManagerManager.Resolve<Dictionary<string, int>>()["handSize"];
    

    public void SetUpStartingHand()
    {
        int shuffleNum = AllCards.Count;
        for(int a=0;a<shuffleNum;a++)
        {
            int cardIndex = Random.Range(0, AllCards.Count);
            Deck.Add(AllCards[cardIndex]);
            AllCards.Remove(AllCards[cardIndex]);
        }

        for (int a = 0; a < startingHandSize; a++)
        {
            Hand.Add(Deck[0]);
            Deck.Remove(Deck[0]);
        }
        reloadHand();
    }

    public void PlayCard(Card card, Player player, Enemy enemy)
    {
        logger.print("cardPlayed!");
        int totalShock=1;
        if (card.Element.Equals("Shock"))
        {
            foreach (Card discardCard in DiscardPile)
            {
                if (discardCard.Element.Equals("Shock"))
                {
                    totalShock++;
                }
            }
        }

        for (int a = 0; a < totalShock; a++)
        {
            CombatSystem.DealDamageToEnemy(card, enemy);
            CombatSystem.GeneratePlayerShield(player, card);
            CombatSystem.ApplyBurnDamageToEnemy(enemy,card);
            CombatSystem.HealPlayer(player,card);
            if (card.DrawCard)
            {
                DrawCard();
            }
        }
        if (!Hand.Contains(card)) Debug.Log("oh no");
        Hand.Remove(card);
        DiscardPile.Add(card);
        reloadHand();
    }

    public void DrawCard()
    {
        if (Deck.Count == 0)
        {
            int discards = DiscardPile.Count;
            for (int a = 0; a < discards; a++)
            {
                Deck.Add(DiscardPile[0]);
                DiscardPile.Remove(DiscardPile[0]);
            }
        }
        Hand.Add(Deck[0]);
        Deck.Remove(Deck[0]);
        
        reloadHand();
    }

    public List<GameObject> cardsGameObj = new List<GameObject>();
    public void reloadHand()
    {
            foreach (GameObject g in cardsGameObj)
            {
               logger.Destroy(g);
            }
        
        int i = 0;
        foreach (Card card in Hand)
        {
            GameObject c = logger.Instantiate(card.gameObject, new Vector3(2.5f - 2.5f * i, -2.5f, 0), new Quaternion());
            cardsGameObj.Add(c);
            c.GetComponent<Card>().origionalCard = card;
            i++;
        }
    }

}