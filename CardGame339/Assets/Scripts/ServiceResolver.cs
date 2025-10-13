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
    public int handSize = 3;
    public Dictionary<string, int> ints;

    public List<Card> allCards;
    public UIManager UImanager = null;
    private void Start()
    {
        ints = new Dictionary<string, int>();
        ints.TryAdd("handSize", handSize);
        //you can only register one thing of each type
        ManagerManager.registerDependency(() => ints);
        ManagerManager.registerDependency(() => logger);
        ManagerManager.registerDependency(() => random);
        ManagerManager.registerDependency(() => UImanager);
        ManagerManager.registerDependency(() => new EnemyManager());
        ManagerManager.registerDependency(() => new CombatSystem());
        ManagerManager.registerDependency(() => new TurnSystem(10));
        ManagerManager.registerDependency(() => new GameManager());
        ManagerManager.registerDependency(() => new Player(10, 0, ""));
        ManagerManager.registerDependency(() => new CardManager());
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


