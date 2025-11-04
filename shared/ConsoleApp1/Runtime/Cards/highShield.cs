
public class highShield : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 9;

    public override int rarity { get; } = 3;
    public override int ShieldValue { get; set; } = 8;
    public override int ManaCost { get; set; } = 2;
    public override int Damage { get; set; } = 0;


    public override string Description { get; } = "Mana Cost:2\nThis card gives 8 shield";

    public override void Effect(Enemy enemy)
    {
    }

    
}
