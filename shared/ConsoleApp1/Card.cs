namespace ConsoleApp1;

public class Card
{
    public string Element;
    public int Damage;
    public int ShieldValue;
    public int BurnDamage;
    public int Heal;

    public Card(string element, int damage, int shieldValue, int burnDamage, int heal)
    {
        Element = element;
        Damage = damage;
        ShieldValue = shieldValue;
        BurnDamage = burnDamage;
        Heal = heal;
    }

}