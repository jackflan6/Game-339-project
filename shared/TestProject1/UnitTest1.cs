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
    
        
    }
}