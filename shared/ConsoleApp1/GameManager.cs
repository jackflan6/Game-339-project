namespace ConsoleApp1;

public class GameManager
{
    private EnemyManager _enemyManager { get; set; }
    public EnemyManager enemyManager
    {
        get => _enemyManager;
        set => _enemyManager = value;
    }
    public GameManager(EnemyManager enemyManagerInput)
    {
        _enemyManager = enemyManagerInput;
        _enemyManager.SetUpEnemies();
    }
}