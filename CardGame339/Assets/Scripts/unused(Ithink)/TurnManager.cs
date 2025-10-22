using System;
using System.Collections.Generic;

public static class TurnManager
{
    public static List<IEnemy> enemys = new List<IEnemy>();
    public static void applyToEnemy(ICard card, int pos)
    {
        card.Effect(enemys[pos]);
    }
    public static void endTurn()
    {
        foreach (IEnemy enemy in enemys)
        {
            enemy.onNewTurn();
        }
    }
    

}
