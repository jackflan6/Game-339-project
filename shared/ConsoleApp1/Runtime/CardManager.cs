using System.Collections.Generic;

namespace ConsoleApp1
{
    public class CardManager
    {
        public List<Card> Deck = new List<Card>();

        public List<Card> Hand = new List<Card>();

        public List<Card> DiscardPile = new List<Card>();

        public CombatSystem CombatSystem;
    

        public CardManager(CombatSystem combatSystem)
    {
        CombatSystem = combatSystem;
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

        public Card SelectCardToPlay()
    {
        //user input in unity
        return new Card("Fire", 0, 0, 0, 0);
    }
    }
}