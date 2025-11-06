
public class mediumShield : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 8;
    public override string Element { get; set; }= "Earth";

    public override int rarity { get; } = 2;
    public override int ShieldValue { get; set; } = 5;
    public override int ManaCost { get; set; } = 2;
    public override int Damage { get; set; } = 0;
    public override string Name { get; set; } = "Wall of Rock_0";


    public override string Description { get; } = "Mana Cost:2\nThis card gives 5 shield";

    public override void Effect(Enemy enemy)
    {
    }

    
}
