namespace TestProject1
{
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
            IDialog dialogue = new ConsoleDialogue();
            IRandom notSoRandom = new FakeRandom();
            EnemyManager enemyManager = new EnemyManager(logger);
            CombatSystem combatSystem = new CombatSystem(enemyManager, logger);
            Card card = new BillowingAss();
            Enemy enemy = new TheBillowedAss(combatSystem, dialogue, enemyManager, notSoRandom);
            combatSystem.DealDamageToEnemy(card, enemy);
            Assert.That(enemy.HP==2);
        }

        [Test]
        public void BurnDamageToPlayer()
        {
            IGameLogger logger = new ConsoleGameLogger();
            Player player = new Player(10,10,"testPlayer", logger);
            player.currentBurnDamage = 2;
            EnemyManager enemyManager = new EnemyManager(logger);
            CombatSystem combatSystem = new CombatSystem(enemyManager, logger);
            combatSystem.BurnDamageToPlayer(player);
            combatSystem.BurnDamageToPlayer(player);
            combatSystem.BurnDamageToPlayer(player);
            logger.print("Player HP: " + player.HP.Value);
            Assert.That(player.HP.Value==7);

        }
    
        
    }
}