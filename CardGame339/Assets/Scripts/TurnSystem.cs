using System.Collections.Generic;
using ConsoleApp1;
using TMPro;

public class TurnSystem : IManager
{
    public EnemyManager enemyManager = ManagerManager.Resolve<EnemyManager>();

    public CombatSystem combatSystem = ManagerManager.Resolve<CombatSystem>();

    public CardManager cardManager = ManagerManager.Resolve<CardManager>();

    public UnityDialogSys UnityDialogSys = ManagerManager.Resolve<UnityDialogSys>();

    public SceneChanger SceneChanger = ManagerManager.Resolve<SceneChanger>();
    
    //public LocationManager locationManager = ManagerManager.Resolve<LocationManager>();
    
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

    public IGameLogger logger { get; } = ManagerManager.Resolve<IGameLogger>();

    public void Start()
    {
        cardManager.SetUpStartingHand();
        PlayerTurn();
    }

    public void Awake()
    {
        
    }

    public void Update()
    {
        
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
        combatSystem.BurnDamageToPlayer(player);
        if (player.HP.Value <= 0)
        {
            logger.print("player lost!");
            UnityDialogSys.PrepareBattleEndDialogue(2);
        }
       logger.print("player turn!");
       isPlayerTurn = true;
       cardManager.DrawCard();
       cardManager.DrawCard();
       cardManager.DrawCard();
       currentMana.Value = MaxMana;
    }

    public void BurnDamageToAllEnemies()
    {
        foreach (Enemy enemy in enemyManager.enemies)
        {
            if(enemy.currentBurnDamage>0)
            {
                combatSystem.BurnDamageToEnemy(enemy);
            }
        }

        for(int a=0;a<enemyManager.enemies.Count;a++)
        {
            if (enemyManager.enemies[a].HP.Value <= 0)
            {
                ManagerManager.Resolve<CurrencyManager>().currencyAmount.Value += enemyManager.enemies[a].dropCurrency.Value;
                enemyManager.DestroyEnemy(enemyManager.enemies[a]);
                a--;
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
            UnityDialogSys dialogSys = ManagerManager.Resolve<UnityDialogSys>();
            LocationManager locationManager = ManagerManager.Resolve<LocationManager>();
            
            dialogSys?.HandleBattleEnd(locationManager);

            return;
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