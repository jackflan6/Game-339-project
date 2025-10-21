using System;

public abstract class Card : ICard
{
    public string Element = "";
    public int ShieldValue;
    public int BurnDamage;
    public int Heal;

    //public abstract int cardID { get; }
    public abstract int ManaCost { get;}
    public abstract int Damage { get; }
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
