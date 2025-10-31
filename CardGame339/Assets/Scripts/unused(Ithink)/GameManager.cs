using System;

public class GameManager : IManager
{
    public EnemyManager enemyManager = ManagerManager.Resolve<EnemyManager>();

    public TurnSystem turnSystem = ManagerManager.Resolve<TurnSystem>();

    public UnityDialogSys DialogSys = ManagerManager.Resolve<UnityDialogSys>();

    public bool battling=true;

    public IGameLogger logger { get; } = ManagerManager.Resolve<IGameLogger>();

    public void Start()
    {
        logger.print("started");
        enemyManager.SetUpEnemies();
        DialogSys.DisplayBattleStartDialogue();
       // PlayBattle();
    }

    public void Awake()
    {
        
    }

    public void Update()
    {
       
    }

    // public void PlayBattle()
    // {
    //     while (battling)
    //     {
    //         print("Player turn!");
    //         turnSystem.PlayerTurn();
    //         if (turnSystem.player.HP<=0)
    //         {
    //             battling = false;
    //             print("Enemy won!");
    //         }
    //         print("Enemy turn!");
    //         turnSystem.EnemiesTurn();
    //         if (enemyManager.enemies.Count == 0)
    //         {
    //             battling = false;
    //             print("Player won!");
    //         }
    //     }
    // }
}