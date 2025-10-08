using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class IEnemy
{
    public List<Enemy> whoKnows;
    public virtual void damage(int val) { }
    public virtual void onNewTurn() { }
    public virtual void applyStatisEffect() { }

    
}
