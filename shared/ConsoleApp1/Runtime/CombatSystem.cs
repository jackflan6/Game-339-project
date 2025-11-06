
using ConsoleApp1;

public class CombatSystem : IManager
{
    // enemy attack dmg
    // player attack dmg
    // we receieve inputs
    // we calculate damage, output result
    
    // TODO: make class variables properly private / public, build out enemy damage to player (unit tests!), build round system, status effects per round 

    readonly EnemyManager enemyManager;
    //public CurrencyManager CurrencyManager;
    public IGameLogger logger { get; }
    
    #if !NOT_UNITY
    public CombatSystem()
    {
        enemyManager = ManagerManager.Resolve<EnemyManager>();
        logger=ManagerManager.Resolve<IGameLogger>();
      //  CurrencyManager = ManagerManager.Resolve<CurrencyManager>();
    }
    #endif
    public CombatSystem(EnemyManager enemyManager, IGameLogger log)
    {
        this.enemyManager = enemyManager;
       // CurrencyManager = currencyManager;
        logger = log;
    }
    public int DealDamageToEnemy(Card card, Enemy enemy)
    {
        int damageDealt = card.Damage;
        damageDealt -= enemy.currentShield.Value;
        enemy.currentShield.Value -= card.Damage;
        if (enemy.currentShield.Value < 0)
        {
            enemy.currentShield.Value = 0;
        }
        if (damageDealt < 0)
        {
            damageDealt = 0;
        }
        enemy.HP.Value -= damageDealt;
        if (enemy.HP.Value <= 0)
        {
            CurrencyManager.currencyAmount.Value += enemy.dropCurrency.Value;
            enemyManager.DestroyEnemy(enemy);
        }
        return enemy.HP.Value;
    }

    public int DealDamageToPlayer(Player player, Enemy enemy)
    {
        int damageDealt = enemy.Attack;
        damageDealt -= player.currentShield.Value;
        player.currentShield.Value -= enemy.Attack;
        if (player.currentShield.Value < 0)
        {
            player.currentShield.Value = 0;
        }
        if (damageDealt < 0)
        {
            damageDealt = 0;
        }
        player.HP.Value -= damageDealt;
        
        return player.HP.Value;
    }
    
    public int GenerateEnemyShield(Enemy enemy)
    {
        enemy.currentShield.Value += enemy.Defense;
        logger.print("Enemy shield is at " + enemy.currentShield.Value + " points!");
        return enemy.currentShield.Value;
    }

    public int GeneratePlayerShield(Player player, Card card)
    {
        player.currentShield.Value += card.ShieldValue;
        return player.currentShield.Value;
    }


    public int BurnDamageToEnemy(Enemy enemy)
    {
        enemy.HP.Value -= enemy.currentBurnDamage;
        enemy.currentBurnDamage /= 2;
        if (enemy.currentBurnDamage == 0)
        {
            enemy.isBurning = false;
        }
        if (enemy.HP.Value <= 0)
        {
            CurrencyManager.currencyAmount.Value += enemy.dropCurrency.Value;
            enemyManager.DestroyEnemy(enemy);
        }

        return enemy.HP.Value;
    }

    public int BurnDamageToPlayer(Player player)
    {
        player.HP.Value -= player.currentBurnDamage;
        player.currentBurnDamage /= 2;
        if (player.currentBurnDamage == 0)
        {
            player.isBurning = false;
        }

        if (player.HP.Value <= 0)
        {
            logger.print("player lost!");
        }

        return player.HP.Value;
    }

    public void ApplyBurnDamageToEnemy(Enemy enemy, Card card)
    {
        enemy.currentBurnDamage += card.BurnDamage;
    }

    public void ApplyBurnDamageToPlayer(Player player, Enemy enemy)
    {
        player.currentBurnDamage += enemy.burnAttackDamage;
    }

    public void HealPlayer(Player player, Card card)
    {
        player.HP.Value += card.Heal;
    }
    
    public void Start()
    {
        
    }

    public void Awake()
    {
       
    }

    public void Update()
    {
        
    }
}