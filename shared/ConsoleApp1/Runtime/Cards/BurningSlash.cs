
using System.Collections.Generic;

public class BurningSlash : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 2;
    public override string Element { get; set; }= "Fire";
    public override int rarity { get; } = 4;
    public override int ManaCost { get; set; } = 3;
    public override int Damage { get; set; } = 6;
    public override int BurnDamage { get; set; } = 4;
    public override string Name { get; set; } = "Burning Slash (1)_0";

    public override string Description { get; } = "Mana Cost: 3\nThis card deals 6 damage and inflicts burn 4";

    public override void Effect(Enemy enemy)
    {
        Burn(enemy);

    }
    
}
