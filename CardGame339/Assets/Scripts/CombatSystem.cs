
public class CombatSystem : IManager
{
    // enemy attack dmg
    // player attack dmg
    // we receieve inputs
    // we calculate damage, output result
    
    // TODO: make class variables properly private / public, build out enemy damage to player (unit tests!), build round system, status effects per round 

    EnemyManager enemyManager = ManagerManager.Resolve<EnemyManager>();
    public int DealDamageToEnemy(Card card, Enemy enemy)
    {
        int damageDealt = card.Damage;
        damageDealt -= enemy.currentShield;
        enemy.currentShield -= card.Damage;
        if (enemy.currentShield < 0)
        {
            enemy.currentShield = 0;
        }
        if (damageDealt < 0)
        {
            damageDealt = 0;
        }
        enemy.HP.Value -= damageDealt;
        if (enemy.HP.Value <= 0)
        {
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
        enemy.currentShield += enemy.Defense;
        return enemy.currentShield;
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
            enemyManager.DestroyEnemy(enemy);
        }

        return enemy.HP.Value;
    }

    public void ApplyBurnDamageToEnemy(Enemy enemy, Card card)
    {
        enemy.currentBurnDamage += card.BurnDamage;
    }

    public void HealPlayer(Player player, Card card)
    {
        player.HP.Value += card.Heal;
    }
    
    
}