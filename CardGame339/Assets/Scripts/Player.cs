using UnityEngine;
using UnityEngine.UI;

public class Player
{
    private readonly IGameLogger _logger = ManagerManager.Resolve<IGameLogger>();

    public int HP;

    public int Defense;

    public string Name;

    public int currentShield;
    public bool isBurning;
    public int currentBurnDamage;
    public Text ShieldText = ManagerManager.Resolve<UIManager>().shieldText;
    
    public Player(int hp, int defense, string name)
    {
        HP = hp;
        Defense = defense;
        Name = name;
    }
    
    
    
}