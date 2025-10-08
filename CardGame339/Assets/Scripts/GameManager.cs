using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemyManager enemyManager;

    public TurnSystem turnSystem;

    public bool battling=true;
    public GameManager(EnemyManager enemyManagerInput, TurnSystem turnSystemInput)
    {
        enemyManager = enemyManagerInput;
        turnSystem = turnSystemInput;
    }

    private void Start()
    {
        print("started");
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