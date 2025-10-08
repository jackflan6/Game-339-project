namespace ConsoleApp1;

public class CombatSystem
{
    // enemy attack dmg
    // player attack dmg
    // we receieve inputs
    // we calculate damage, output result
    
    // TODO: make class variables properly private / public, build out enemy damage to player (unit tests!), build round system, status effects per round 
    
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
        enemy.HP -= damageDealt;
        
        return enemy.HP;
    }

    public int DealDamageToPlayer(Player player, Enemy enemy)
    {
        int damageDealt = enemy.Attack;
        damageDealt -= player.currentShield;
        player.currentShield -= enemy.Attack;
        if (player.currentShield < 0)
        {
            player.currentShield = 0;
        }
        if (damageDealt < 0)
        {
            damageDealt = 0;
        }
        player.HP -= damageDealt;
        
        return player.HP;
    }
    
    public int GenerateEnemyShield(Enemy enemy)
    {
        enemy.currentShield += enemy.Defense;
        return enemy.currentShield;
    }

    public int GeneratePlayerShield(Player player)
    {
        player.currentShield += player.Defense;
        return player.currentShield;
    }

    public int BurnDamageToEnemy(Enemy enemy)
    {
        enemy.HP -= enemy.currentBurnDamage;
        enemy.currentBurnDamage /= 2;
        if (enemy.currentBurnDamage == 0)
        {
            enemy.isBurning = false;
        }

        return enemy.HP;
    }
    
    
}