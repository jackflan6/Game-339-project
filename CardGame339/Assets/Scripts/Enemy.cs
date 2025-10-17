using System;
using Game.Runtime;
using TMPro;
using Unity.VisualScripting;


public abstract class Enemy : IEnemy
{
    public abstract int HP { get; set; }
    public abstract int Attack { get; set; }
    public int Defense;
    public string Name;


    public int currentShield;

    public bool isBurning;

    public int currentBurnDamage;

    public TextMeshProUGUI HPText;
    public TextMeshProUGUI DialogueText;

    public abstract void DoAction(Player player,Enemy enemy);

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