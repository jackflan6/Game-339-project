public class Player
{
     readonly IGameLogger _logger;

    public ValueHolder<int> HP = new ValueHolder<int>();

    public int Defense;

    public string Name;

    public ValueHolder<int> currentShield = new ValueHolder<int>();
    public bool isBurning;
    public int currentBurnDamage;
    
    #if !NOT_UNITY
    public Player(int hp, int defense, string name)
    {
        _logger = ManagerManager.Resolve<IGameLogger>();
        HP.Value = hp;
        Defense = defense;
        Name = name;
    }
    #endif

    public Player(int hp, int defense, string name, IGameLogger logger)
    {
        _logger = logger;
        HP.Value = hp;
        Defense = defense;
        Name = name;
    }
    
    
    
}