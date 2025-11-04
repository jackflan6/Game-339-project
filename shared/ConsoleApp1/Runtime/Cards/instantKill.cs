
using System.Collections.Generic;

public class instantKill : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 16;
    public override int rarity { get; } = 4;

    public override int ShieldValue { get; set; } = 0;
    public override int Heal { get; set; } = 0;
    public override int ManaCost { get; set; } = 5;
    public override int Damage { get; set; } = 999;

    public override int BurnDamage { get; set; } = 0;

    public override string Description { get; } = "Mana cost: 5\nThis card deals 999 damage";

    public override void Effect(Enemy enemy)
    {
        Burn(enemy);
    }
    
}
