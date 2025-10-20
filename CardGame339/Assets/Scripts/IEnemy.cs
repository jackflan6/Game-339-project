using System;
using System.Collections.Generic;

public interface IEnemy
{
    public ValueHolder<int> HP { get; set; }
    public int Attack { get; set; }
    public virtual void damage(int val) { }
    public virtual void onNewTurn() { }
    public virtual void applyStatisEffect() { }

    
}
