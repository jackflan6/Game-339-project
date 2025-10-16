using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class TurnSystem : IManager
{
    public EnemyManager enemyManager;

    public CombatSystem combatSystem;

    public CardManager cardManager;
    public Enemy EnemyToAttack;

    public IRandom random;
    public Player player;

    public int MaxMana;
    public int currentMana;
    public bool isPlayerTurn;
    public Card cardToPlay;
    public Text ManaText;
    public Text PlayerHP;

    public TurnSystem(int maxMana)
    {
        MaxMana = maxMana;
        currentMana = MaxMana;
    }

    public override void Awake()
    {
        enemyManager = ManagerManager.Resolve<EnemyManager>();
        combatSystem = ManagerManager.Resolve<CombatSystem>();
        cardManager = ManagerManager.Resolve<CardManager>();
        random = ManagerManager.Resolve<IRandom>();
        player = ManagerManager.Resolve<Player>();
        ManaText = ManagerManager.Resolve<UIManager>().manaText;
        PlayerHP = ManagerManager.Resolve<UIManager>().playerHP;
        ManaText.text = "Mana: " + currentMana;
        PlayerHP.text = "HP: " + player.HP;
    }
    public override void Start()
    {
        cardManager.SetUpStartingHand();
        PlayerTurn();
    }
    
    public void EnemiesTurn()
    {
        logger.print("enemies Turn");
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
            logger.print("player lost!");
        }

        PlayerTurn();
    }

    public void PlayerTurn()
    {
       logger.print("player turn!");
       isPlayerTurn = true;
       cardManager.DrawCard();
       currentMana = MaxMana;
       UpdateText("Mana: "+currentMana);
    }

    public void BurnDamageToAllEnemies()
    {
        for (int a=0;a<enemyManager.enemies.Count;a++)
        {
            if (enemyManager.enemies[a].currentBurnDamage>0)
            {
                combatSystem.BurnDamageToEnemy(enemyManager.enemies[a]);
            }
        }
    }

    public void SelectEnemyToAttack(Enemy enemy)
    {
        //user input in unity
        if (isPlayerTurn && hasClickedOnCard())
        {
            currentMana -= cardToPlay.ManaCost;
            EnemyToAttack = enemy;
            cardManager.PlayCard(cardToPlay,player,EnemyToAttack);
            UpdateText("Mana: " + currentMana);
            UpdateHPText("HP: " + player.HP);
            UpdateShieldText("Shield: " + player.currentShield);
            cardToPlay = null;
        }
    }
    public void SelectCardToPlay(Card card)
    {
        if (isPlayerTurn && card.ManaCost<=currentMana)
        {
            cardToPlay = card;
        }
    }

    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        if (enemyManager.enemies.Count == 0)
        {
            logger.print("Player won!");
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
    
}