
using System.Collections.Generic;

public class ultraDefense : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 15;
    public override int rarity { get; } = 4;

    public override int ShieldValue { get; set; } = 10;
    public override int Heal { get; set; } = 10;
    public override int ManaCost { get; set; } = 3;
    public override int Damage { get; set; } = 0;

    public override int BurnDamage { get; set; } = 0;

    public override string Description { get; } = "Mana cost: 3\nThis card gives you 5 shield and heals 5 HP";

    public override void Effect(Enemy enemy)
    {
        Burn(enemy);
    }
    
}
