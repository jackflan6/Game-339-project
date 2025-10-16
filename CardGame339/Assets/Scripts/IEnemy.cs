using System;
using UnityEngine;
using System.Collections.Generic;

public interface IEnemy
{
    public virtual void damage(int val) { }
    public virtual void onNewTurn() { }
    public virtual void applyStatisEffect() { }

    
}
