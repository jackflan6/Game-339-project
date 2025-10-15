using System;
using UnityEngine;
[Serializable]
public class ICard
{
    public int ManaCost{ get; set; }
    public void Effect(IEnemy enemy) { }
    
}
