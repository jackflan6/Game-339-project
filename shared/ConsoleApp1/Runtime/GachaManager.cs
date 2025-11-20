using System.Collections.Generic;

public class GachaManager : IManager
{
    public readonly IRandom Random;
    public List<Card> gachaItems = new List<Card>()
    {
        new BillowingAss(), //omni (appears in all packs)
        new instantKill(), //lightning
        new ultraDefense(), //earth
        new BurningSlash(), //fire
        new completeRefresh(), //wind
        new trueRecovery(), //omni (appears in all packs)
        new healCard(), //omni (appears in all packs)
        new mediumHeal(), //omni (appears in all packs)
        new highHeal(), //omni (appears in all packs)
        new shieldCard(), //earth
        new mediumShield(), //earth
        new highShield(), //earth
        new lowDamage(), //lightning
        new mediumDamage(), //lightning
        new highDamage(), //lightning
        new lowBurn(), //fire
        new mediumBurn(), //fire
        new highBurn(), //fire
        new lowDraw(), //wind
        new mediumDraw(), //wind
        new highDraw() //wind
    };

    private int legendaryPityCounter;
    private int rarePityCounter;
    private int hardPity;

#if !NOT_UNITY
    public GachaManager()
    {
        logger = ManagerManager.Resolve<IGameLogger>();
        Random = ManagerManager.Resolve<IRandom>();
    }
#endif

    public GachaManager(IGameLogger log,IRandom ran)
    {
        logger = log;
        Random = ran;
    }

    public Card Pull(List<Card> allCards)
    {
        int chance=Random.RandomNumber(100);
        if (chance < 1 || legendaryPityCounter==89)
        {
            
            List<Card> legendaryItems = CollectLegendaryCards(allCards);
            int legendaryItem = Random.RandomNumber(legendaryItems.Count);
            rarePityCounter = 0;
            legendaryPityCounter = 0;
            return legendaryItems[legendaryItem];
        }
        else if(chance<20 || rarePityCounter==9)
        {
            List<Card> rareCards = CollectRareCards(allCards);
            int rareCard = Random.RandomNumber(rareCards.Count);
            rarePityCounter = 0;
            legendaryPityCounter++;
            return rareCards[rareCard];
        }
        else if(chance<30)
        {
            List<Card> epicCards = CollectEpicCards(allCards);
            int epicCard = Random.RandomNumber(epicCards.Count);
            rarePityCounter = 0;
            legendaryPityCounter++;
            return epicCards[epicCard];
        }
        
        List<Card> commonCards = CollectCommonCards(allCards);
        int commonCard = Random.RandomNumber(commonCards.Count);
        legendaryPityCounter++;
        rarePityCounter++;
        return commonCards[commonCard];
        
    }
    
    public Card PullHigherChances(List<Card> allCards)
    {
        int chance=Random.RandomNumber(100);
        if (chance < 5 || legendaryPityCounter==89)
        {
            
            List<Card> legendaryItems = CollectLegendaryCards(allCards);
            int legendaryItem = Random.RandomNumber(legendaryItems.Count);
            rarePityCounter = 0;
            legendaryPityCounter = 0;
            return legendaryItems[legendaryItem];
        }
        else if(chance<25 || rarePityCounter==9)
        {
            List<Card> rareCards = CollectRareCards(allCards);
            int rareCard = Random.RandomNumber(rareCards.Count);
            rarePityCounter = 0;
            legendaryPityCounter++;
            return rareCards[rareCard];
        }
        else if(chance<35)
        {
            List<Card> epicCards = CollectEpicCards(allCards);
            int epicCard = Random.RandomNumber(epicCards.Count);
            rarePityCounter = 0;
            legendaryPityCounter++;
            return epicCards[epicCard];
        }
        
        List<Card> commonCards = CollectCommonCards(allCards);
        int commonCard = Random.RandomNumber(commonCards.Count);
        legendaryPityCounter++;
        rarePityCounter++;
        return commonCards[commonCard];
        
    }

    private Card PullFireCard(List<Card> allCards)
    {
        List<Card> fireCards = CollectFireCards(allCards);
        return PullHigherChances(fireCards);
    }
    
    private Card PullLightningCard(List<Card> allCards)
    {
        List<Card> lightningCards = CollectLightningCards(allCards);
        return PullHigherChances(lightningCards);
    }
    
    private Card PullWindCard(List<Card> allCards)
    {
        List<Card> windCards = CollectWindCards(allCards);
        return PullHigherChances(windCards);
    }
    
    private Card PullEarthCard(List<Card> allCards)
    {
        List<Card> earthCards = CollectEarthCards(allCards);
        return PullHigherChances(earthCards);
    }

    public List<Card> PullPack(List<Card> allCards)
    {
        List<Card> pullResults = new List<Card>();
        for (int a = 0; a < 5; a++)
        {
            pullResults.Add(PullHigherChances(allCards));
        }

        return pullResults;
    }
    
    public List<Card> PullFireFiveTimes(List<Card> allCards)
    {
        int omniCards = 0;
        List<Card> pullResults = new List<Card>();
        for (int a = 0; a < 5; a++)
        {
            Card receivedCard = PullFireCard(allCards);
            if (receivedCard.Element.ToLower().Equals("omni"))
            {
                omniCards++;
            }

            while (receivedCard.Element.ToLower().Equals("omni") && omniCards > 2)
            {
                receivedCard = PullFireCard(allCards);
            }
            pullResults.Add(receivedCard);
        }

        return pullResults;
    }
    
    public List<Card> PullLightningFiveTimes(List<Card> allCards)
    {
        int omniCards = 0;
        List<Card> pullResults = new List<Card>();
        for (int a = 0; a < 5; a++)
        {
            Card receivedCard = PullLightningCard(allCards);
            if (receivedCard.Element.ToLower().Equals("omni"))
            {
                omniCards++;
            }

            while (receivedCard.Element.ToLower().Equals("omni") && omniCards > 2)
            {
                receivedCard = PullLightningCard(allCards);
            }
            pullResults.Add(receivedCard);
        }

        return pullResults;
    }
    
    public List<Card> PullWindFiveTimes(List<Card> allCards)
    {
        int omniCards = 0;
        List<Card> pullResults = new List<Card>();
        for (int a = 0; a < 5; a++)
        {
            Card receivedCard = PullWindCard(allCards);
            if (receivedCard.Element.ToLower().Equals("omni"))
            {
                omniCards++;
            }

            while (receivedCard.Element.ToLower().Equals("omni") && omniCards > 2)
            {
                receivedCard = PullWindCard(allCards);
            }
            pullResults.Add(receivedCard);
        }

        return pullResults;
    }
    
    public List<Card> PullEarthFiveTimes(List<Card> allCards)
    {
        int omniCards = 0;
        List<Card> pullResults = new List<Card>();
        for (int a = 0; a < 5; a++)
        {
            Card receivedCard = PullEarthCard(allCards);
            if (receivedCard.Element.ToLower().Equals("omni"))
            {
                omniCards++;
            }

            while (receivedCard.Element.ToLower().Equals("omni") && omniCards > 2)
            {
                receivedCard = PullEarthCard(allCards);
            }
            pullResults.Add(receivedCard);
        }
        return pullResults;
    }
    
    public List<Card> PullOmniFiveTimes(List<Card> allCards)
    {
        List<Card> pullResults = new List<Card>();
        for (int a = 0; a < 5; a++)
        {
            pullResults.Add(PullOmniCard(allCards));
        }

        return pullResults;
    }
    
    public List<Card> PullLegendaryFiveTimes(List<Card> allCards)
    {
        List<Card> pullResults = new List<Card>();
        for (int a = 0; a < 5; a++)
        {
            pullResults.Add(PullLegendaryCard(allCards));
        }

        return pullResults;
    }

    private Card PullOmniCard(List<Card> allCards)
    {
        List<Card> omniCards = CollectOmniCards(allCards);
        return PullHigherChances(omniCards);
    }

    public Card PullLegendaryCard(List<Card> allCards)
    {
        List<Card> legendaryItems = CollectLegendaryCards(allCards);
        int legendaryItem = Random.RandomNumber(legendaryItems.Count);
        rarePityCounter = 0;
        legendaryPityCounter = 0;
        return legendaryItems[legendaryItem];
    }

    private List<Card> CollectFireCards(List<Card> allCards)
    {
        List<Card> fireCards = new List<Card>();
        foreach (Card card in gachaItems)
        {
            if (card.Element.ToLower().Equals("fire") || card.Element.ToLower().Equals("omni"))
            {
                fireCards.Add(card);
            }
        }

        return fireCards;
    }
    
    private List<Card> CollectOmniCards(List<Card> allCards)
    {
        List<Card> omniCards = new List<Card>();
        foreach (Card card in allCards)
        {
            if (card.Element.ToLower().Equals("omni"))
            {
                omniCards.Add(card);
            }
        }

        return omniCards;
    }
    
    private List<Card> CollectWindCards(List<Card> allCards)
    {
        List<Card> windCards = new List<Card>();
        foreach (Card card in allCards)
        {
            if (card.Element.ToLower().Equals("wind") || card.Element.ToLower().Equals("omni"))
            {
                windCards.Add(card);
            }
        }

        return windCards;
    }
    
    private List<Card> CollectEarthCards(List<Card> allCards)
    {
        List<Card> earthCards = new List<Card>();
        foreach (Card card in allCards)
        {
            if (card.Element.ToLower().Equals("earth") || card.Element.ToLower().Equals("omni"))
            {
                earthCards.Add(card);
            }
        }

        return earthCards;
    }
    
    private List<Card> CollectLightningCards(List<Card> allCards)
    {
        List<Card> fireCards = new List<Card>();
        foreach (Card card in allCards)
        {
            if (card.Element.ToLower().Equals("lightning") || card.Element.ToLower().Equals("omni"))
            {
                fireCards.Add(card);
            }
        }

        return fireCards;
    }

    private List<Card> CollectLegendaryCards(List<Card> allCards)
    {
        List<Card> legendaryCards = new List<Card>();
        foreach (Card card in allCards)
        {
            if (card.rarity==4)
            {
                legendaryCards.Add(card);
            }
        }

        return legendaryCards;
    }

    private List<Card> CollectRareCards(List<Card> allCards)
    {
        List<Card> rareCards = new List<Card>();
        foreach (Card card in allCards)
        {
            if (card.rarity==2)
            {
                rareCards.Add(card);
            }
        }

        return rareCards;
    }
    
    private List<Card> CollectEpicCards(List<Card> allCards)
    {
        List<Card> epicCards = new List<Card>();
        foreach (Card card in allCards)
        {
            if (card.rarity==3)
            {
                epicCards.Add(card);
            }
        }

        return epicCards;
    }
    
    private List<Card> CollectCommonCards(List<Card> allCards)
    {
        List<Card> commonCards = new List<Card>();
        foreach (Card card in allCards)
        {
            if (card.rarity==1)
            {
                commonCards.Add(card);
            }
        }

        return commonCards;
    }

    public IGameLogger logger { get; }
    public void Start()
    {
        
    }

    public void Awake()
    {
        
    }

    public void Update()
    {
        
    }
}