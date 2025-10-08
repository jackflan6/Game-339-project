using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public EnemyManager enemyManager;

    public CombatSystem combatSystem;

    public CardManager cardManager;
    public Enemy EnemyToAttack;

    private IRandom _random;
    public Player player;

    public int MaxMana;
    public int currentMana;
    public bool isPlayerTurn;

    public TurnSystem(EnemyManager enemyManagerInput, CombatSystem combatSystemInput, Player playerInput,
        IRandom random, CardManager cardManagerInput, int maxMana)
    {
        enemyManager = enemyManagerInput;
        combatSystem = combatSystemInput;
        player = playerInput;
        _random = random;
        cardManager = cardManagerInput;
        MaxMana = maxMana;
    }

    private void Awake()
    {
        cardManager.SetUpStartingHand();
    }
    
    public void EnemiesTurn()
    {
        BurnDamageToAllEnemies();
        foreach (Enemy enemy in enemyManager.enemies)
        {
            int chooseAction=_random.RandomNumber(2);
            if (chooseAction == 0)
            {
                combatSystem.DealDamageToPlayer(player, enemy);
            }

            if (chooseAction == 1)
            {
                combatSystem.GenerateEnemyShield(enemy);
            }
        }
    }

    public void PlayerTurn()
    {
        cardManager.DrawCard();
        currentMana = MaxMana;
        while (isPlayerTurn)
        {
            Card cardToPlay = cardManager.cardToPlay;
            while (cardToPlay.ManaCost > currentMana)
            {
                cardToPlay = cardManager.cardToPlay;
            }
            currentMana -= cardToPlay.ManaCost;

            Enemy enemyToAttack = EnemyToAttack;
            cardManager.PlayCard(cardToPlay, player, enemyToAttack);
            if (enemyToAttack.IsDead())
            {
                enemyManager.enemies.Remove(enemyToAttack);
            }

            cardToPlay = null;
            enemyToAttack = null;
        }
    }

    public void BurnDamageToAllEnemies()
    {
        foreach (Enemy enemy in enemyManager.enemies)
        {
            if (enemy.currentBurnDamage>0)
            {
                combatSystem.BurnDamageToEnemy(enemy);
                if (enemy.IsDead())
                {
                    enemyManager.enemies.Remove(enemy);
                }
            }
        }
    }

    public void SelectEnemyToAttack()
    {
        //user input in unity
        print("clicked!");
        EnemyToAttack = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Enemy>();
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