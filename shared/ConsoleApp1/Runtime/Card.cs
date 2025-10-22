using System;
using System.Collections.Generic;

public abstract class Card : ICard
{
    public string Element = "";
    public virtual int ShieldValue { get; set; }
    public virtual int burnDamage { get; set; }
    public virtual int Heal { get; set; }

    //public abstract int cardID { get; }
    public abstract int ManaCost { get;}
    public abstract int Damage { get; }
    public abstract void Effect(Enemy enemy);

    
    public void DrawCard()
    {
        ManagerManager.Resolve<CardManager>().DrawCard();
    }
    public void DamageEnemy(int damage,Enemy enemy)
    {
        ManagerManager.Resolve<CombatSystem>().DealDamageToEnemy(this,enemy);
    }

    public void Burn(Enemy enemy)
    {
        ManagerManager.Resolve<CombatSystem>().ApplyBurnDamageToEnemy(enemy,this);
    }

}
