
using System.Collections.Generic;

public class completeRefresh : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 20;
    public override int rarity { get; } = 4;
    public override string Element { get; set; }= "Wind";
    public override int ShieldValue { get; set; } = 3;
    public override int Heal { get; set; } = 5;
    public override int ManaCost { get; set; } = 3;
    public override int Damage { get; set; } = 0;
    public override string Name { get; set; } = "Complete Refresh_0";

    public override int BurnDamage { get; set; } = 0;

    public override string Description { get; } = "Mana cost: 3\nThis card gives you 3 shield, heals 5 HP, and draws 2 cards";

    public override void Effect(Enemy enemy)
    {
        DrawCard();
        DrawCard();
    }
    
}
