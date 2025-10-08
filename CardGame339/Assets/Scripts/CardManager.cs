using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour 
{
    public List<Card> Deck = new List<Card>();

    public List<Card> Hand = new List<Card>();

    public List<Card> DiscardPile = new List<Card>();

    public List<Card> AllCards;
    public CombatSystem CombatSystem;

    public Card cardToPlay;

    public int startingHandSize;
    

    public CardManager(CombatSystem combatSystem)
    {
        CombatSystem = combatSystem;
    }

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
    }

    public void PlayCard(Card card, Player player, Enemy enemy)
    {
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
        DiscardPile.Add(card);
    }

    public void DrawCard()
    {
        Hand.Add(Deck[0]);
        Deck.Remove(Deck[0]);
    }

    public void SelectCardToPlay()
    {
        //user input in unity
        cardToPlay = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Card>();
    }
}