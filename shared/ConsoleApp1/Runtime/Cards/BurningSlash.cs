
using System.Collections.Generic;

public class BurningSlash : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 2;

    public override int rarity {set; get;}
    public override int ManaCost { get; set; } = 1;
    public override int Damage { get; set; } = 3;
    public override int BurnDamage { get; set; } = 2;

    public override void Effect(Enemy enemy)
    {
        Burn(enemy);

    }
}
