using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly IGameLogger _logger;
    
    private int _HP { get; set; }
    public int HP
    {
        get => _HP;
        set => _HP = value;
    }

    private int _Attack { get; set; }
    public int Attack
    {
        get => _Attack;
        set => _Attack = value;
    }
    private int _Defense { get; set; }
    public int Defense
    {
        get => _Defense;
        set => _Defense = value;
    }
    private string _Name { get; set; }
    public string Name
    {
        get => _Name;
        set => _Name = value;
    }

    private int _currentShield;
    public int currentShield
    {
        get => _currentShield;
        set => _currentShield = value;
    }
    private bool _isBurning { get; set; }
    public bool isBurning
    {
        get => _isBurning;
        set => _isBurning = value;
    }
    private int _currentBurnDamage { get; set; }
    public int currentBurnDamage
    {
        get => _currentBurnDamage;
        set => _currentBurnDamage = value;
    }
    
    public Player(int hp, int attack, int defense, string name, IGameLogger logger)
    {
        _logger = logger;
        _HP = hp;
        _Attack = attack;
        _Defense = defense;
        _Name = name;
    }
    
    
    
}