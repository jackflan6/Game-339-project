using System.Collections.Generic;

public class GachaManager
{
    public readonly IRandom Random;
    public List<GachaItem> gachaItems = new List<GachaItem>()
    {
        new GachaItem(3, "Prius"),
        new GachaItem(4,"Cadillac"),
        new GachaItem(3, "CRV"),
        new GachaItem(3, "Hyundai"),
        new GachaItem(4, "Mustang"),
        new GachaItem(5, "Maserati",false,true),
        new GachaItem(5, "Corvette", true),
        new GachaItem(5, "Rolls Royce", true),
        new GachaItem(5, "Tesla", true)
    };

    private int premiumPityCounter;
    private int fourStarPityCounter;
    private int hardPity;
    private bool hasGuarantee;

    public GachaManager(IRandom random)
    {
        Random = random;
    }

    public GachaItem Pull()
    {
        int chance=Random.RandomNumber(100);
        if (chance == 0 || premiumPityCounter==89)
        {
            int fiveStarFiftyFifty = Random.RandomNumber(2);
            if (fiveStarFiftyFifty == 0)
            {
                hasGuarantee = false;
                premiumPityCounter = 0;
                foreach (GachaItem item in gachaItems)
                {
                    if (item.isOnBanner)
                    {
                        return item;
                    }
                }
            }
            else
            {
                List<GachaItem> standardItems = CollectStandardFiveStars();
                int standardFiveStar = Random.RandomNumber(standardItems.Count);
                hasGuarantee = true;
                premiumPityCounter = 0;
                return standardItems[standardFiveStar];
            }
        }
        else if(chance==1 || chance==2 || chance==3 || chance==4 || chance==5 || fourStarPityCounter==9)
        {
            List<GachaItem> fourStars = CollectFourStarItems();
            int fourStar = Random.RandomNumber(fourStars.Count);
            fourStarPityCounter = 0;
            premiumPityCounter++;
            return fourStars[fourStar];
        }
        
        List<GachaItem> threeStars = CollectThreeStarItems();
        int threeStar = Random.RandomNumber(threeStars.Count);
        premiumPityCounter++;
        fourStarPityCounter++;
        return threeStars[threeStar];
        
    }

    private List<GachaItem> CollectStandardFiveStars()
    {
        List<GachaItem> standardItems = new List<GachaItem>();
        foreach (GachaItem item in gachaItems)
        {
            if (item.isStandard)
            {
                standardItems.Add(item);
            }
        }

        return standardItems;
    }

    private List<GachaItem> CollectFourStarItems()
    {
        List<GachaItem> fourStarItems = new List<GachaItem>();
        foreach (GachaItem item in gachaItems)
        {
            if (item.Rarity==4)
            {
                fourStarItems.Add(item);
            }
        }

        return fourStarItems;
    }
    
    private List<GachaItem> CollectThreeStarItems()
    {
        List<GachaItem> threeStarItems = new List<GachaItem>();
        foreach (GachaItem item in gachaItems)
        {
            if (item.Rarity==3)
            {
                threeStarItems.Add(item);
            }
        }

        return threeStarItems;
    }
}