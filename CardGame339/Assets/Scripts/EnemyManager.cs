using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : IManager
{
    private readonly IGameLogger _logger;
    public List<Enemy> enemies = ManagerManager.Resolve<List<Enemy>>();

    public List<string> enemyTaunts = new List<string>()
    {
        "Let's see if you can handle this next attack!",
        "I'll take you down!",
        "You were a fool to challenge me!"
    };

    public void SetUpEnemies()
    {
       // CreateEnemy(5, 5, 5, "1", _logger);
      //  CreateEnemy(7, 7, 7, "2", _logger);
    }
    
    public Enemy CreateEnemy(int hp, int attack, int defense, string name, IGameLogger logger)
    {
        Enemy enemy = new Enemy(hp, attack, defense, name, logger);
        enemies.Add(enemy);
        return enemy;
    }
}