

using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    List<Card> cards;
    List<Card> unlockedCards;
    public Inventory()
    {
        createInitialCards();
    }

    private void createInitialCards()
    {
        List<Card> cards = new List<Card>();
        cards.Add(new BillowingAss());
        cards.Add(new mediumHeal());
        cards.Add(new lowDamage());
        cards.Add(new lowBurn());
        cards.Add(new lowDraw());
        cards.Add(new mediumBurn());
        cards.Add(new mediumDamage());
        cards.Add(new mediumDraw());
        cards.Add(new mediumShield());
        cards.Add(new instantKill());
        cards.Add(new completeRefresh());
        SetAllCardsInInventory(cards);
        SetAllUnlockedCardsInInventory(cards);
    }

    public List<Card> GetAllCardsInInventory()
    {
        return cards;
    }

    public void AddCardsInInventory(Card c)
    {
        cards.Add(c);
    }
    public void RemoveCardsInInventory(Card c)
    {
        cards.Remove(c);
    }
    public void SetAllCardsInInventory(List<Card> c)
    {
        cards = new List<Card>(c);
    }
    public void SetAllUnlockedCardsInInventory(List<Card> c)
    {
        unlockedCards = new List<Card>(c);
    }

    public void unlockCard(Card c)
    {
        unlockedCards.Add(c);
    }
    public List<Card> GetAllCardsUnlocked()
    {
        return unlockedCards;
    }
    public Lazy<Dictionary<int, Type>> GetAllCardIDs = new Lazy<Dictionary<int, Type>>(() =>
    {
        Dictionary<int, Type> CardIDs = new Dictionary<int, Type>();

        IEnumerable<Type> c = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsSubclassOf(typeof(Card)));

        foreach (Type t in c)
        {
            CardIDs.TryAdd((int)t.GetField("cardID").GetValue(null), t);
        }
        return CardIDs;
    });
}