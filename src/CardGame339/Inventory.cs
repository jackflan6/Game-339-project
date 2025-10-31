

using System.Collections.Generic;

public class Inventory
{
    List<Card> cards;
    CardManager cardManager;
    List<Card> unlockedCards;
    public Inventory(CardManager c)
    {
        cardManager = c;
    }

    public List<Card> GetAllCardsInInventory()
    {
        List<Card> ret = new List<Card>();
        return ret;
    }

    public void SetAllCardsInInventory(List<Card> c)
    {
        cards = c;
    }

    public void unlockCard(Card c)
    {
        unlockedCards.Add(c);
    }
    

}