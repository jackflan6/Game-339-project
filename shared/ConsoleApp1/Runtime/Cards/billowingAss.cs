
using System.Collections.Generic;

public class BillowingAss : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 1;
    public override string Element { get; set; }= "Omni";
    public override int rarity { get; } = 4;

    public override int ShieldValue { get; set; } = 5;
    public override int Heal { get; set; } = 5;
    public override int ManaCost { get; set; } = 4;
    public override int Damage { get; set; } = 5;

    public override int BurnDamage { get; set; } = 5;

    public override string Description { get; } = "Mana cost: 4\nThis card gives you 5 shield, heals 5 HP, deals 5 damage, 5 burn damage, and draws a card";

    public override void Effect(Enemy enemy)
    {
        DrawCard();
        Burn(enemy);
    }
    
}
