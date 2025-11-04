
using System.Collections.Generic;

public class mediumBurn : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 13;

    public override int rarity { get; } = 2;
    public override int ManaCost { get; set; } = 3;
    public override int Damage { get; set; } = 0;
    public override int BurnDamage { get; set; } = 4;

    public override string Description { get; } = "Mana Cost: 3\nThis card deals inflicts burn 4";

    public override void Effect(Enemy enemy)
    {
        Burn(enemy);

    }
    
}
