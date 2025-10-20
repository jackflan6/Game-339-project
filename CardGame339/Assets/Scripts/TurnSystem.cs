using System.Collections.Generic;
using TMPro;

public class TurnSystem : IManager
{
    public EnemyManager enemyManager = ManagerManager.Resolve<EnemyManager>();

    public CombatSystem combatSystem = ManagerManager.Resolve<CombatSystem>();

    public CardManager cardManager = ManagerManager.Resolve<CardManager>();

    public UnityDialogSys UnityDialogSys = ManagerManager.Resolve<UnityDialogSys>();
    
    public Enemy EnemyToAttack;

    public IRandom random = ManagerManager.Resolve<IRandom>();
    public Player player = ManagerManager.Resolve<Player>();

    public int MaxMana;
    public ValueHolder<int> currentMana = new ValueHolder<int>();
    public bool isPlayerTurn;
    public Card cardToPlay;

    public TurnSystem(int maxMana)
    {
        MaxMana = maxMana;
        currentMana.Value = MaxMana;
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
            enemy.DoAction(player,enemy);
            
        }

        if (player.HP.Value <= 0)
        {
            logger.print("player lost!");
            UnityDialogSys.PrepareBattleEndDialogue(2);
        }

        PlayerTurn();
    }

    public void PlayerTurn()
    {
       logger.print("player turn!");
       isPlayerTurn = true;
       cardManager.DrawCard();
       currentMana.Value = MaxMana;
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
            currentMana.Value -= cardToPlay.ManaCost;
            EnemyToAttack = enemy;
            cardManager.PlayCard(cardToPlay,player,EnemyToAttack);
            cardToPlay = null;
        }
    }
    public void SelectCardToPlay(Card card)
    {
        if (isPlayerTurn && card.ManaCost <= currentMana.Value)
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
            UnityDialogSys.PrepareBattleEndDialogue(1);
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

    
    
}