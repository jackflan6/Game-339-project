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
    public Player player
    {
        get => _player;
        set => _player = value;
    }

    public int MaxMana;
    public int currentMana;
    public bool isPlayerTurn;

    public TurnSystem(EnemyManager enemyManagerInput, CombatSystem combatSystemInput, Player playerInput,
        IRandom random, CardManager cardManagerInput, int maxMana)
    {
        _enemyManager = enemyManagerInput;
        _combatSystem = combatSystemInput;
        _player = playerInput;
        _random = random;
        _cardManager = cardManagerInput;
        MaxMana = maxMana;
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

    public void PlayerTurn()
    {
        cardManager.DrawCard();
        currentMana = MaxMana;
        while (isPlayerTurn)
        {
            Card cardToPlay = cardManager.SelectCardToPlay();
            while (cardToPlay.ManaCost > currentMana)
            {
                cardToPlay = cardManager.SelectCardToPlay();
            }
            currentMana -= cardToPlay.ManaCost;

            Enemy enemyToAttack = SelectEnemyToAttack();
            cardManager.PlayCard(cardToPlay, _player, enemyToAttack);
            if (enemyToAttack.IsDead())
            {
                enemyManager.enemies.Remove(enemyToAttack);
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

    public Enemy SelectEnemyToAttack()
    {
        //user input in unity
        return enemyManager.enemies[0];
    }

    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
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