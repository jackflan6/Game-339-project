

using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    List<Card> cards;
    List<Card> unlockedCards;
    List<Type> unlockedCardsTypes;
    public Inventory()
    {
        createInitialCards();
    }

    private void createInitialCards()
    {
        List<Card> cards = new List<Card>();
        cards.Add(new healCard());
        cards.Add(new lowDamage());
        cards.Add(new lowBurn());
        cards.Add(new shieldCard());
        cards.Add(new lowDraw());
        SetAllCardsInInventory(cards);
        SetAllUnlockedCardsInInventory(cards);
    }

    public List<Card> GetAllCardsInInventory()
    {
        return cards;
    }

    public void AddCardsInInventory(Card c)
    {
        if (!cards.Contains(c))
        {
            cards.Add(c);
        }
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
        unlockedCardsTypes = new List<Type>();
        foreach (Card _c in unlockedCards)
        {
            unlockedCardsTypes.Add(_c.GetType());
        }
    }

    public void unlockCard(Card c)
    {
        if (!unlockedCardsTypes.Contains(c.GetType())) { 
        unlockedCards.Add(c);
        unlockedCardsTypes.Add(c.GetType());
        }
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