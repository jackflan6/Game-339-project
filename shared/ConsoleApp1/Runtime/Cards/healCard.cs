
public class healCard : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 5;

    public override int rarity { get; set; }
    public override int Heal { get; set; } = 3;
    public override int ManaCost { get; set; } = 1;
    public override int Damage { get; set; } = 0;

    public override void Effect(Enemy enemy)
    {
    }

    public override int rarity { get; } = 1;
}
