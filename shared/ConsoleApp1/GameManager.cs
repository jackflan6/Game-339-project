namespace ConsoleApp1
{
    public class GameManager
    {
        private EnemyManager _enemyManager { get; set; }
        public EnemyManager enemyManager
        {
            get => _enemyManager;
            set => _enemyManager = value;
        }
    
        private TurnSystem _turnSystem { get; set; }
        public TurnSystem turnSystem
        {
            get => _turnSystem;
            set => _turnSystem = value;
        }

        public bool battling;
        public GameManager(EnemyManager enemyManagerInput, TurnSystem turnSystemInput)
    {
        _enemyManager = enemyManagerInput;
        _enemyManager.SetUpEnemies();
        _turnSystem = turnSystemInput;
    }

        public void PlayBattle()
    {
        while (battling)
        {
            turnSystem.PlayerTurn();
            if (turnSystem.player.HP<=0)
            {
                battling = false;
            }
            turnSystem.EnemiesTurn();
            if (enemyManager.enemies.Count == 0)
            {
                battling = false;
            }
        }
    }
    }
}