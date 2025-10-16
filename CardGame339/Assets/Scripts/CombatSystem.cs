using Unity.VisualScripting;
using UnityEngine;
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
        enemy.HP -= damageDealt;
        enemy.HPText.text = "HP: " +enemy.HP;
        if (enemy.HP <= 0)
        {
            enemyManager.enemies.Remove(enemy);
            enemy.gameObject.SetActive(false);
        }
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
        player.ShieldText.text = "Shield: " + player.currentShield;
        
        return player.HP;
    }
    
    public int GenerateEnemyShield(Enemy enemy)
    {
        enemy.currentShield += enemy.Defense;
        return enemy.currentShield;
    }

    public int GeneratePlayerShield(Player player, Card card)
    {
        player.currentShield += card.ShieldValue;
        return player.currentShield;
    }

    public void EnemyTalk(Enemy enemy, string message)
    {
        if (enemy.GetComponent<DialogueDisplayer>() == null)
        {
            enemy.AddComponent<DialogueDisplayer>();
        }
        enemy.GetComponent<DialogueDisplayer>().DisplayDialogue(message, enemy.gameObject);
    }

    public int BurnDamageToEnemy(Enemy enemy)
    {
        enemy.HP -= enemy.currentBurnDamage;
        enemy.currentBurnDamage /= 2;
        if (enemy.currentBurnDamage == 0)
        {
            enemy.isBurning = false;
        }
        if (enemy.HP <= 0)
        {
            enemyManager.enemies.Remove(enemy);
            enemy.gameObject.SetActive(false);
        }
        enemy.HPText.text = "HP: " + enemy.HP;

        return enemy.HP;
    }

    public void ApplyBurnDamageToEnemy(Enemy enemy, Card card)
    {
        enemy.currentBurnDamage += card.BurnDamage;
    }

    public void HealPlayer(Player player, Card card)
    {
        player.HP += card.Heal;
    }
    
    
}