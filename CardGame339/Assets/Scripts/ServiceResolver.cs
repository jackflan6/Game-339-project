using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ServiceResolver : MonoBehaviour
{
    public ServiceResolver(IGameLogger logger)
    {
        this.logger = logger;
    }
    public IGameLogger logger;
    public IRandom random;
    [Header("Player")]
    public int handSize = 3;
    public int playerHP = 20;
    public string playerName;
    public int maxMana;
    public Dictionary<string, int> ints;
    [Header("Cards")]
    public List<Card> allCards;
    [Header("UI")]
    public UIManager UImanager = null;
    private void Start()
    {
        //you can only register one thing of each type
        ManagerManager.registerDependency(() => logger);
        ManagerManager.registerDependency(() => random);
        ManagerManager.registerDependency(() => UImanager);
        ManagerManager.registerDependency(() => new EnemyManager());
        ManagerManager.registerDependency(() => new CombatSystem());
        ManagerManager.registerDependency(() => new TurnSystem(maxMana));
        ManagerManager.registerDependency(() => new GameManager());
        ManagerManager.registerDependency(() => new Player(playerHP, 0, playerName));
        ManagerManager.registerDependency(() => new CardManager(handSize));
        ManagerManager.registerDependency(() => allCards);
        foreach (Func<object> manager in ManagerManager.managers)
        {
            (manager() as IManager).Awake();
            (manager() as IManager).Start();
        }
    }
    private void Update()
    {
        foreach (Func<object> manager in ManagerManager.managers)
        {
            (manager() as IManager).Update();
        }
    }

    public void EndPlayerTurn()
    {
        ManagerManager.Resolve<TurnSystem>().EndPlayerTurn();
    }

    public void SelectedEnemy(Enemy enemy)
    {
        ManagerManager.Resolve<TurnSystem>().SelectEnemyToAttack(enemy);
    }
    public void SelectedCard(Card card)
    {
        ManagerManager.Resolve<TurnSystem>().SelectCardToPlay(card);
    }
}


