using ConsoleApp1;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PlayerDamageToEnemy()
    {
        IGameLogger logger=new ConsoleGameLogger();
        CombatSystem combatSystem = new CombatSystem();
        Card card = new Card("Fire", 5, 0, 0, 0);
        Enemy enemy = new Enemy(6, 6, 5, "TestEnemy", logger);
        combatSystem.DealDamageToEnemy(card, enemy);
        Assert.That(enemy.HP==1);
    }
    
    [Test]
    public void EnemyDamageToPlayer()
    {
        IGameLogger logger = new ConsoleGameLogger();
        CombatSystem combatSystem = new CombatSystem();
        Player player = new Player(5, 5, 5, "Test", logger);
        logger.Info(player.HP.ToString());
        Enemy enemy = new Enemy(6, 6, 6, "TestEnemy", logger);
        combatSystem.DealDamageToPlayer(player, enemy);
        Assert.That(player.HP==-1);
    }

    [Test]
    public void EnemyGenerateShield1x()
    {
        IGameLogger logger = new ConsoleGameLogger();
        CombatSystem combatSystem = new CombatSystem();
        Card card = new Card("Fire", 5, 0, 0, 0);
        Enemy enemy = new Enemy(10, 3, 3, "TestEnemy", logger);
        combatSystem.GenerateEnemyShield(enemy);
        combatSystem.DealDamageToEnemy(card, enemy);
        Assert.That(enemy.HP==8);
    }
    
    [Test]
    public void EnemyGenerateShield2x()
    {
        IGameLogger logger = new ConsoleGameLogger();
        CombatSystem combatSystem = new CombatSystem();
        Card card = new Card("Fire", 5, 0, 0, 0);
        Enemy enemy = new Enemy(10, 3, 3, "TestEnemy", logger);
        combatSystem.GenerateEnemyShield(enemy);
        combatSystem.GenerateEnemyShield(enemy);
        combatSystem.DealDamageToEnemy(card, enemy);
        Assert.That(enemy.HP==10);
    }
    
    [Test]
    public void PlayerAttack2xToGetThroughShield()
    {
        IGameLogger logger = new ConsoleGameLogger();
        CombatSystem combatSystem = new CombatSystem();
        Card card = new Card("Fire", 5, 0, 0, 0);
        Enemy enemy = new Enemy(10, 3, 6, "TestEnemy", logger);
        combatSystem.GenerateEnemyShield(enemy);
        combatSystem.DealDamageToEnemy(card, enemy);
        combatSystem.DealDamageToEnemy(card, enemy);
        Assert.That(enemy.HP==6);
    }
    
    [Test]
    public void PlayerGenerateShield1x()
    {
        IGameLogger logger = new ConsoleGameLogger();
        CombatSystem combatSystem = new CombatSystem();
        Player player = new Player(10, 3, 3, "TestPlayer", logger);
        Enemy enemy = new Enemy(10, 5, 5, "TestEnemy", logger);
        combatSystem.GeneratePlayerShield(player);
        combatSystem.DealDamageToPlayer(player, enemy);
        Assert.That(player.HP==8);
    }
    
    [Test]
    public void PlayerGenerateShield2x()
    {
        IGameLogger logger = new ConsoleGameLogger();
        CombatSystem combatSystem = new CombatSystem();
        Player player = new Player(10, 3, 3, "TestPlayer", logger);
        Enemy enemy = new Enemy(10, 5, 5, "TestEnemy", logger);
        combatSystem.GeneratePlayerShield(player);
        combatSystem.GeneratePlayerShield(player);
        combatSystem.DealDamageToPlayer(player, enemy);
        Assert.That(player.HP==10);
    }
    
    [Test]
    public void EnemyAttack2xToGetThroughShield()
    {
        IGameLogger logger = new ConsoleGameLogger();
        CombatSystem combatSystem = new CombatSystem();
        Enemy enemy = new Enemy(5, 5, 5, "TestEnemy", logger);
        Player player = new Player(10, 3, 6, "TestEnemy", logger);
        combatSystem.GeneratePlayerShield(player);
        combatSystem.DealDamageToPlayer(player, enemy);
        combatSystem.DealDamageToPlayer(player, enemy);
        Assert.That(player.HP==6);
    }

    [Test]
    public void EnemyTurnGenerateShield()
    {
        IGameLogger logger = new ConsoleGameLogger();
        IRandom controlledRandom = new FakeRandom2();
        Player player = new Player(10,5,5,"TestPlayer",logger);
        EnemyManager enemyManager = new EnemyManager(logger);
        enemyManager.CreateEnemy(5, 5, 5, "Hello", logger);
        CombatSystem combatSystem = new CombatSystem();
        TurnSystem turnSystem = new TurnSystem(enemyManager, combatSystem, player,controlledRandom);
        turnSystem.EnemiesTurn();
        Assert.That(enemyManager.enemies[0].currentShield>0);
    }
    
    [Test]
    public void EnemyTurnAttackPlayer()
    {
        IGameLogger logger = new ConsoleGameLogger();
        IRandom controlledRandom = new FakeRandom();
        Player player = new Player(10,5,5,"TestPlayer",logger);
        EnemyManager enemyManager = new EnemyManager(logger);
        enemyManager.CreateEnemy(5, 5, 5, "Hello", logger);
        CombatSystem combatSystem = new CombatSystem();
        TurnSystem turnSystem = new TurnSystem(enemyManager, combatSystem, player,controlledRandom);
        turnSystem.EnemiesTurn();
        Assert.That(player.HP==5);
    }
    
    [Test]
    public void EnemyBurnDamage()
    {
        IGameLogger logger = new ConsoleGameLogger();
        IRandom controlledRandom = new FakeRandom2();
        Player player = new Player(10,5,5,"TestPlayer",logger);
        EnemyManager enemyManager = new EnemyManager(logger);
        enemyManager.CreateEnemy(5, 5, 5, "Hello", logger);
        enemyManager.enemies[0].currentBurnDamage = 2;
        CombatSystem combatSystem = new CombatSystem();
        TurnSystem turnSystem = new TurnSystem(enemyManager, combatSystem, player,controlledRandom);
        turnSystem.EnemiesTurn();
        turnSystem.EnemiesTurn();
        turnSystem.EnemiesTurn();
        Assert.That(enemyManager.enemies[0].HP==2);
    }
}