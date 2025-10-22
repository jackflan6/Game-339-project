using System;
using System.Collections.Generic;

public abstract class Card : ICard
{
    public string Element = "";
    //if one of these attributs are not used you no not need to implement it into a card
    public virtual int ShieldValue { get; set; }
    public virtual int BurnDamage { get; set; }
    public virtual int Heal { get; set; }

    //you do need to implement these though
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
