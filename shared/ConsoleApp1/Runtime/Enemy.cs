using System;


public abstract class Enemy : IEnemy
{
    public abstract ValueHolder<int> HP { get; set; }
    public abstract int Attack { get; set; }
    public abstract int Defense { get; set; }
    
    public abstract ValueHolder<int> dropCurrency { get; }
    
    public abstract int burnAttackDamage { get; }
    public string Name;


    public abstract ValueHolder<int> currentShield { get; set; }

    public bool isBurning;

    public int currentBurnDamage;


    public abstract void DoAction(Player player,Enemy enemy);

    public bool IsDead()
    {
        if (HP.Value <= 0)
        {
            return true;
        }

        return false;
    }

}