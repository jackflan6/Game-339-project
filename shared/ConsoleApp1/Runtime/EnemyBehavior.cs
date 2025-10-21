using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public static class EnemyBehavior
    {
    
        private static Dictionary<int, Action<Enemy>> possibleActions =
            new Dictionary<int, Action<Enemy>>()
            {
                {0, Attack},
                {1, Defend}
            };
    
        public static void TakeTurn(Enemy enemy)
    {
        if (enemy.isBurning)
        {
            //enemy.TakeDamage(enemy.currentBurnDamage);
            enemy.currentBurnDamage/=2;
            if (enemy.currentBurnDamage == 0)
            {
                enemy.isBurning = false;
            }
        }
        if (!enemy.IsDead())
        {
            Random ActionPicker = new Random();
            int actionToDo = ActionPicker.Next(possibleActions.Count);
            possibleActions[actionToDo].Invoke(enemy);
        }
        //GameManager.EndBattle with player victory

    }

        public static void Attack(Enemy enemy)
    {
         //returns an int that needs to be given to player
    }

        public static void Defend(Enemy enemy)
    {
         //returns an int that needs to be given to player
    }
    
    }
}