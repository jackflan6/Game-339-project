public class GachaItem
{
    public int Rarity;
    public string Name;
    public bool isStandard;
    public bool isOnBanner;

    public GachaItem()
    {
        Rarity = 3;
        Name = "";
        isStandard = false;
    }

    public GachaItem(int r, string n, bool standard=false, bool banner=false)
    {
        Rarity = r;
        Name = n;
        isStandard = standard;
        isOnBanner = banner;
    }

    public override string ToString()
    {
        string s = Name + " Rarity: " + Rarity;
        return s;
    }
}
