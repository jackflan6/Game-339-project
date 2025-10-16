
public class billowingAss : Card
{
    //it is nessasary to have every card have a static int for its ID
    public static int cardID = 1;
    //public override int cardID { get { return staticCardID; } }//this is also needed
    public override int ManaCost { get; } = 1;
    public override int Damage { get; } = 1;

    public override void Effect(IEnemy enemy)
    {
        
    }
}
