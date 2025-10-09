using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public EnemyManager enemyManager;

    public CombatSystem combatSystem;

    public CardManager cardManager;
    public Enemy EnemyToAttack;

    public UnityRandom random;
    public Player player;

    public int MaxMana;
    public int currentMana;
    public bool isPlayerTurn;
    public Card cardToPlay;
    public Text ManaText;
    public Text PlayerHP;

    public TurnSystem(EnemyManager enemyManagerInput, CombatSystem combatSystemInput, Player playerInput,
        UnityRandom randomInput, CardManager cardManagerInput, int maxMana)
    {
        enemyManager = enemyManagerInput;
        combatSystem = combatSystemInput;
        player = playerInput;
        random = randomInput;
        cardManager = cardManagerInput;
        MaxMana = maxMana;
        currentMana = MaxMana;
    }

    private void Awake()
    {
        cardManager.SetUpStartingHand();
        ManaText.text = "Mana: " + currentMana;
        PlayerHP.text = "HP: " + player.HP;
    }

    private void Start()
    {
        PlayerTurn();
    }
    
    public void EnemiesTurn()
    {
        print("enemies Turn");
        BurnDamageToAllEnemies();
        foreach (Enemy enemy in enemyManager.enemies)
        {
            int chooseAction=random.RandomNumber(2);
            if (chooseAction == 0)
            {
                combatSystem.DealDamageToPlayer(player, enemy);
                UpdateHPText("HP: " + player.HP);
            }

            if (chooseAction == 1)
            {
                combatSystem.GenerateEnemyShield(enemy);
            }
        }

        if (player.HP <= 0)
        {
            print("player lost!");
        }

        PlayerTurn();
    }

    public void PlayerTurn()
    {
        print("player turn!");
        isPlayerTurn = true;
       // cardManager.DrawCard();
        currentMana = MaxMana;
        UpdateText("Mana: "+currentMana);
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
        if (isPlayerTurn && hasClickedOnCard())
        {
            EnemyToAttack = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Enemy>();
            cardManager.PlayCard(cardToPlay,player,EnemyToAttack);
            UpdateText("Mana: " + currentMana);
            UpdateHPText("HP: " + player.HP);
            UpdateShieldText("Shield: " + player.currentShield);
            cardToPlay = null;
        }
    }
    public void SelectCardToPlay()
    {
        if (isPlayerTurn && UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Card>().ManaCost<=currentMana)
        {
            cardToPlay = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Card>();
            currentMana -= cardToPlay.ManaCost;
        }
    }

    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        if (enemyManager.enemies.Count == 0)
        {
            print("Player won!");
        }
        EnemiesTurn();
    }
    
    public bool hasClickedOnCard()
    {
        if (cardToPlay != null)
        {
            return true;
        }

        return false;
    }

    public void UpdateText(string message)
    {
        ManaText.text = message;
    }

    public void UpdateHPText(string message)
    {
        PlayerHP.text = message;
    }

    public void UpdateShieldText(string message)
    {
        player.ShieldText.text = message;
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