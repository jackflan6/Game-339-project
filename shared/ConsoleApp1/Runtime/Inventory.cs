

using System.Collections.Generic;

public class Inventory
{
    List<Card> cards;
    List<Card> unlockedCards;
    public Inventory()
    {
    }

    public List<Card> GetAllCardsInInventory()
    {
        return cards;
    }

    public void AddCardsInInventory(Card c)
    {
        cards.Add(c);
    }
    public void SetAllCardsInInventory(List<Card> c)
    {
        cards = c;
    }

    public void unlockCard(Card c)
    {
        unlockedCards.Add(c);
    }
    public List<Card> GetAllCardsUnlocked()
    {
        return unlockedCards;
    }

}