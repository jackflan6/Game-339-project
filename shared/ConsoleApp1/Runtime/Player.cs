public class Player
{
    private readonly IGameLogger _logger = ManagerManager.Resolve<IGameLogger>();

    public ValueHolder<int> HP = new ValueHolder<int>();

    public int Defense;

    public string Name;

    public ValueHolder<int> currentShield = new ValueHolder<int>();
    public bool isBurning;
    public int currentBurnDamage;
    
    public Player(int hp, int defense, string name)
    {
        HP.Value = hp;
        Defense = defense;
        Name = name;
    }
    
    
    
}