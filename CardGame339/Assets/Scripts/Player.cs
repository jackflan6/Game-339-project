using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private readonly IGameLogger _logger;

    public int HP;

    public int Attack;

    public int Defense;

    public string Name;

    public int currentShield;
    public bool isBurning;
    public int currentBurnDamage;
    public Text ShieldText;
    
    public Player(int hp, int attack, int defense, string name, IGameLogger logger)
    {
        _logger = logger;
        HP = hp;
        Attack = attack;
        Defense = defense;
        Name = name;
    }
    
    
    
}