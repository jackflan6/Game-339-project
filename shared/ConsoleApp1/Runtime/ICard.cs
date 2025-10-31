using System;
public interface ICard
{
    public int ManaCost{ get; }
    public int Damage { get; }
    public abstract void Effect(Enemy enemy);
    
}
