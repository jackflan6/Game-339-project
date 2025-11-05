
public class mediumDraw : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 18;
    public override string Element { get; set; }= "Wind";
    public override int rarity { get; } = 2;
    public override int ManaCost { get; set; } = 3;
    public override int Damage { get; set; } = 0;


    public override string Description { get; } = "Mana Cost:13 \nThis card draws 2 cards";

    public override void Effect(Enemy enemy)
    {
        DrawCard();
        DrawCard();
    }
    
}
