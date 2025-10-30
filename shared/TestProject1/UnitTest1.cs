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
            logger.print("enemy HP: " + enemy.HP.Value);
            Assert.That(enemy.HP==4);
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

        [Test]
        public void GachaPull1x()
        {
            IRandom fakeRandom= new RealRandom();
            IGameLogger logger = new ConsoleGameLogger();
            GachaManager gachaManager = new GachaManager(fakeRandom);
            logger.print(gachaManager.Pull(gachaManager.gachaItems).ToString());
        }
        
        [Test]
        public void GachaPull10x()
        {
            List<Card> itemsPulled = new List<Card>();
            IRandom fakeRandom= new RealRandom();
            IGameLogger logger = new ConsoleGameLogger();
            GachaManager gachaManager = new GachaManager(fakeRandom);
            for (int a = 0; a < 10; a++)
            {
                Card newItem = gachaManager.Pull(gachaManager.gachaItems);
                logger.print(newItem.ToString());
                itemsPulled.Add(newItem);
            }

            bool containsRareCard = false;
            foreach (Card item in itemsPulled)
            {
                if (item.rarity >= 2)
                {
                     containsRareCard = true;
                }
            }
            Assert.That(containsRareCard);
        }

        [Test]
        public void GachaPullx90()
        {
            List<Card> itemsPulled = new List<Card>();
            IRandom fakeRandom= new RealRandom();
            IGameLogger logger = new ConsoleGameLogger();
            GachaManager gachaManager = new GachaManager(fakeRandom);
            for (int a = 0; a < 90; a++)
            {
                Card newItem = gachaManager.Pull(gachaManager.gachaItems);
                logger.print(newItem.ToString());
                itemsPulled.Add(newItem);
            }

            int rareCards = 0;
            foreach (Card item in itemsPulled)
            {
                if (item.rarity >= 2)
                {
                    rareCards++;
                }
            }

            bool containsLegendaryCard = false;
            foreach (Card item in itemsPulled)
            {
                if (item.rarity == 4)
                {
                    containsLegendaryCard = true;
                }
            }
            Assert.That(rareCards>=9&&containsLegendaryCard);
        }
        


    }
}