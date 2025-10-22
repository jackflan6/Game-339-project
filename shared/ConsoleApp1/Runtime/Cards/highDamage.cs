
public class highDamage : Card
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "cardID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int cardID = 3;

    public override int ManaCost { get; } = 3;
    public override int Damage { get; } = 5;


    public override void Effect(Enemy enemy)
    {
    }
}
