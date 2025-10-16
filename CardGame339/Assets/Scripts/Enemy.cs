using Game.Runtime;
using TMPro;
using UnityEditor.EngineDiagnostics;
using UnityEngine;

public class Enemy : ObserverMonoBehaviour, IEnemy
{
    private readonly IGameLogger _logger;

    private ObservableValue<int> _observableHp;
    
    private ObservableValue<int> observableHp => _observableHp ??= new ObservableValue<int>(UiHp);

    public int HP
    {
        get => observableHp.Value;
        set => observableHp.Value = value;
    }

    public int UiHp;
    
    public int Attack;

    public int Defense;

    public string Name;


    public int currentShield;

    public bool isBurning;

    public int currentBurnDamage;

    public TextMeshProUGUI HPText;
    public TextMeshProUGUI DialogueText;

    public Enemy(int hp, int attack, int defense, string name, IGameLogger logger)
    {
        _logger = logger;
        HP = hp;
        Attack = attack;
        Defense = defense;
        Name = name;
    }

    public bool IsDead()
    {
        if (HP <= 0)
        {
            return true;
        }

        return false;
    }

    protected override void Subscribe()
    {
        observableHp.ChangeEvent += ObservableHpOnChangeEvent;
    }

    private void ObservableHpOnChangeEvent(int obj)
    {
        HPText.text = "WAT HP: " + obj;
    }

    protected override void Unsubscribe()
    {
        observableHp.ChangeEvent -= ObservableHpOnChangeEvent;
    }
}