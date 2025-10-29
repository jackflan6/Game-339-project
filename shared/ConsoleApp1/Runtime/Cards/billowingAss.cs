
using System.Collections.Generic;

public class BillowingAss : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 1;
    public override int rarity { get; set; }

    public override int ShieldValue { get; set; } = 1;
    public override int Heal { get; set; } = 1;
    public override int ManaCost { get; } = 2;
    public override int Damage { get; set; }

    public override int BurnDamage { get; set; } = 1;

    public override void Effect(Enemy enemy)
    {
        Damage = 1 + rarity;
        Burn(enemy);
    }
}
