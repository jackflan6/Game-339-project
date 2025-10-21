using System.Collections.Generic;

namespace ConsoleApp1
{
    public class EnemyManager
    {
        private readonly IGameLogger _logger;
        public List<Enemy> enemies = new List<Enemy>();

        public EnemyManager(IGameLogger logger)
    {
        _logger = logger;
    }

        public void SetUpEnemies()
    {
        CreateEnemy(5, 5, 5, "1", _logger);
        CreateEnemy(7, 7, 7, "2", _logger);
    }
    
        public Enemy CreateEnemy(int hp, int attack, int defense, string name, IGameLogger logger)
    {
        Enemy enemy = new Enemy(hp, attack, defense, name, logger);
        enemies.Add(enemy);
        return enemy;
    }
    }
}