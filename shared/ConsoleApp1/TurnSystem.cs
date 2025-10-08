using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1;

public class TurnSystem
{
    private EnemyManager _enemyManager { get; set; }
    public EnemyManager enemyManager
    {
        get => _enemyManager;
        set => _enemyManager = value;
    }
    
    private CombatSystem _combatSystem { get; set; }

    public CombatSystem combatSystem
    {
        get => _combatSystem;
        set => _combatSystem = value;
    }
    
    private CardManager _cardManager { get; set; }

    public CardManager cardManager
    {
        get => _cardManager;
        set => _cardManager = value;
    }

    private IRandom _random;
    
    private Player _player { get; set; }

    public TurnSystem(EnemyManager enemyManagerInput, CombatSystem combatSystemInput, Player playerInput,
        IRandom random)
    {
        _enemyManager = enemyManagerInput;
        _combatSystem = combatSystemInput;
        _player = playerInput;
        _random = random;
    }
    
    public void EnemiesTurn()
    {
        BurnDamageToAllEnemies();
        foreach (Enemy enemy in _enemyManager.enemies)
        {
            int chooseAction=_random.RandomNumber(2);
            if (chooseAction == 0)
            {
                _combatSystem.DealDamageToPlayer(_player, enemy);
            }

            if (chooseAction == 1)
            {
                _combatSystem.GenerateEnemyShield(enemy);
            }
        }
    }

    public void BurnDamageToAllEnemies()
    {
        foreach (Enemy enemy in _enemyManager.enemies)
        {
            if (enemy.currentBurnDamage>0)
            {
                _combatSystem.BurnDamageToEnemy(enemy);
                if (enemy.IsDead())
                {
                    _enemyManager.enemies.Remove(enemy);
                }
            }
        }
    }

    // public int CalculateTotalShock()
    // {
    //     int totalShock;
    //     foreach (Card card in discardPile)
    //     {
    //         if (card.hasShock)
    //         {
    //             totalShock++;
    //         }
    //     }
    //
    //     return totalShock;
    // }
    //
    // public void PlayCard(Card card)
    // {
    //     Action cardEffect;
    //     if (card.hasShock)
    //     {
    //         int shock=CalculateTotalShock();
    //         for (int a = 0; a < discardPile.length; a++)
    //         {
    //             cardEffect.Invoke();
    //         }
    //     }
    //
    // }
}