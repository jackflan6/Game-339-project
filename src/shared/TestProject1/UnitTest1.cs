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
            logger.print(gachaManager.Pull().ToString());
        }
        
        [Test]
        public void GachaPull10x()
        {
            List<GachaItem> itemsPulled = new List<GachaItem>();
            IRandom fakeRandom= new RealRandom();
            IGameLogger logger = new ConsoleGameLogger();
            GachaManager gachaManager = new GachaManager(fakeRandom);
            for (int a = 0; a < 10; a++)
            {
                GachaItem newItem = gachaManager.Pull();
                logger.print(newItem.ToString());
                itemsPulled.Add(newItem);
            }

            bool containsFourStar = false;
            foreach (GachaItem item in itemsPulled)
            {
                if (item.Rarity == 4)
                {
                    containsFourStar = true;
                }
            }
            Assert.That(containsFourStar);
        }

        [Test]
        public void GachaPullx90()
        {
            List<GachaItem> itemsPulled = new List<GachaItem>();
            IRandom fakeRandom= new RealRandom();
            IGameLogger logger = new ConsoleGameLogger();
            GachaManager gachaManager = new GachaManager(fakeRandom);
            for (int a = 0; a < 90; a++)
            {
                GachaItem newItem = gachaManager.Pull();
                logger.print(newItem.ToString());
                itemsPulled.Add(newItem);
            }

            int fourStars = 0;
            foreach (GachaItem item in itemsPulled)
            {
                if (item.Rarity == 4)
                {
                    fourStars++;
                }
            }

            bool containsFiveStar = false;
            foreach (GachaItem item in itemsPulled)
            {
                if (item.Rarity == 5)
                {
                    containsFiveStar = true;
                }
            }
            Assert.That(fourStars>=9&&containsFiveStar);
        }
        


    }
}