using System;

public abstract class Card : ICard
{
    public string Element = "";
    public abstract int ShieldValue { get; }
    public abstract int Heal { get; }

    //public abstract int cardID { get; }
    public abstract int ManaCost { get;}
    public abstract int Damage { get; }
    public abstract int BurnDamage { get; }
    public abstract void Effect(IEnemy enemy);

    
    public void DrawCard()
    {
        ManagerManager.Resolve<CardManager>().DrawCard();
    }
    public void DamageEnemy(int damage,Enemy enemy)
    {
        ManagerManager.Resolve<CombatSystem>().DealDamageToEnemy(this,enemy);
    }
}
