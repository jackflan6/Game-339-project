using System;
using System.Collections.Generic;
using System.Linq;
using Random = System.Random;

public class CardManager : IManager
{
    public List<Card> Deck = new List<Card>();
    public List<Card> Hand = new List<Card>();
    
    public List<Card> DiscardPile = new List<Card>();
    public List<Card> AllCards;


    public CombatSystem CombatSystem = ManagerManager.Resolve<CombatSystem>();

    public int startingHandSize;

    public Lazy<Dictionary<int, Type>> GetAllCardIDs = new Lazy<Dictionary<int, Type>>(() =>
    {
        Dictionary<int, Type> CardIDs = new Dictionary<int, Type>();
        IEnumerable<Type> c = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsSubclassOf(typeof(Card)));
        foreach (Type t in c)
        {
            ManagerManager.Resolve<IGameLogger>().print(t.Name);
            CardIDs.TryAdd((int)t.GetField("cardID").GetValue(null),t);
        }
        return CardIDs ;
    });





    private Random random = new Random();

    public CardManager(int handsize)
    {
        startingHandSize = handsize;
    }

    public event Action<Card> CardDraw;
    public event Action<Card> CardPlayed;
    public void SetUpStartingHand()
    {
        int shuffleNum = AllCards.Count;
        for(int a=0;a<shuffleNum;a++)
        {
            int cardIndex = random.Next(0, AllCards.Count);
            Deck.Add(AllCards[cardIndex]);
            AllCards.Remove(AllCards[cardIndex]);
        }
        logger.print("num of cards in deck " + Deck.Count);

        for (int a = 0; a < startingHandSize; a++)
        {
            DrawCard();
        }
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
            card.Effect(enemy);
            CombatSystem.DealDamageToEnemy(card, enemy);
            CombatSystem.GeneratePlayerShield(player, card);
            CombatSystem.ApplyBurnDamageToEnemy(enemy,card);
            CombatSystem.HealPlayer(player,card);
        }
        Hand.Remove(card);
        DiscardPile.Add(card);

        if (CardPlayed != null) CardPlayed.Invoke(card);
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
        if (CardDraw != null) CardDraw.Invoke(Deck[0]);
        Hand.Add(Deck[0]);
        Deck.Remove(Deck[0]);
    }


}