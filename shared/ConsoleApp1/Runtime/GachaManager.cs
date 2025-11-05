using System.Collections.Generic;

public class GachaManager : IManager
{
    public readonly IRandom Random;
    public List<Card> gachaItems = new List<Card>()
    {
        new BillowingAss(), //ultra rare special (appears in all packs)
        new instantKill(), //lightning
        new ultraDefense(), //earth
        new BurningSlash(), //fire
        new healCard(), //common (appears in all packs)
        new mediumHeal(), //common (appears in all packs)
        new highHeal(), //common (appears in all packs)
        new shieldCard(), //earth
        new mediumShield(), //earth
        new highShield(), //earth
        new lowDamage(), //lightning
        new mediumDamage(), //lightning
        new highDamage(), //lightning
        new lowBurn(), //fire
        new mediumBurn(), //fire
        new highBurn() //fire
        //draw card variants (low, mid, high)
    };

    private int legendaryPityCounter;
    private int rarePityCounter;
    private int hardPity;
    private bool hasGuarantee;

    public GachaManager(IRandom random)
    {
        Random = random;
    }

    public Card Pull(List<Card> allCards)
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
        else if(chance<30 || rarePityCounter==9)
        {
            List<Card> rareCards = CollectRareCards(allCards);
            int rareCard = Random.RandomNumber(rareCards.Count);
            rarePityCounter = 0;
            legendaryPityCounter++;
            return rareCards[rareCard];
        }
        else if(chance<40)
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

    public Card PullFireCard(List<Card> allCards)
    {
        List<Card> fireCards = CollectFireCards(allCards);
        return Pull(fireCards);
    }
    
    public Card PullLightningCard(List<Card> allCards)
    {
        List<Card> lightningCards = CollectLightningCards(allCards);
        return Pull(lightningCards);
    }

    private List<Card> CollectFireCards(List<Card> allCards)
    {
        List<Card> fireCards = new List<Card>();
        foreach (Card card in gachaItems)
        {
            if (card.Element.ToLower().Equals("fire"))
            {
                fireCards.Add(card);
            }
        }

        return fireCards;
    }
    
    private List<Card> CollectLightningCards(List<Card> allCards)
    {
        List<Card> fireCards = new List<Card>();
        foreach (Card card in gachaItems)
        {
            if (card.Element.ToLower().Equals("lightning"))
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