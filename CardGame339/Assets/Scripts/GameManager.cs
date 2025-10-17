using System;

public class GameManager : IManager
{
    public EnemyManager enemyManager = ManagerManager.Resolve<EnemyManager>();

    public TurnSystem turnSystem = ManagerManager.Resolve<TurnSystem>();

    public bool battling=true;

    public override void Start()
    {
        logger.print("started");
        enemyManager.SetUpEnemies();
       // PlayBattle();
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