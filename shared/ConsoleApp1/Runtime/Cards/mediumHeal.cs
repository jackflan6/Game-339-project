
public class mediumHeal : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 10;

    public override int rarity { get; } = 2;
    public override int Heal { get; set; } = 7;
    public override int ManaCost { get; set; } = 1;
    public override int Damage { get; set; } = 0;

    public override string Description { get; } = "Mana Cost: 1\nThis card heals 7 HP";

    public override void Effect(Enemy enemy)
    {
    }
    
}
