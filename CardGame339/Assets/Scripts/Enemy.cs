using System;
using Game.Runtime;
using TMPro;
using UnityEditor.EngineDiagnostics;
using UnityEngine;

[Serializable]
public class ObservableInt : ObservableValue<int>, ISerializationCallbackReceiver
{
    [SerializeField] private int initialValue;

    public void OnAfterDeserialize() => Value = initialValue;
    public void OnBeforeSerialize() => initialValue = Value;
}

public class Enemy : ObserverMonoBehaviour, IEnemy
{
    private readonly IGameLogger _logger;
    
    public int Attack;
    public ObservableInt HP;

    public int Defense;

    public string Name;


    public int currentShield;

    public bool isBurning;

    public int currentBurnDamage;

    public TextMeshProUGUI HPText;
    public TextMeshProUGUI DialogueText;

    public Enemy(int hp, int attack, int defense, string name, IGameLogger logger)
    {
        HP = new ObservableInt();
        _logger = logger;
        HP.Value = hp;
        Attack = attack;
        Defense = defense;
        Name = name;
    }

    public bool IsDead()
    {
        if (HP.Value <= 0)
        {
            return true;
        }

        return false;
    }

    protected override void Subscribe()
    {
        HP.ChangeEvent += ObservableHpOnChangeEvent;
    }

    private void ObservableHpOnChangeEvent(int obj)
    {
        HPText.text = "WAT HP: " + obj;
    }

    protected override void Unsubscribe()
    {
        HP.ChangeEvent -= ObservableHpOnChangeEvent;
    }
}