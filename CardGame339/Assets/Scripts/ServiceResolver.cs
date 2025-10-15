using System;
using System.Collections.Generic;
using UnityEngine;


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
    public List<Enemy> allEnemys;
    public UIManager UImanager = null;
    private void Start()
    {
        ints = new Dictionary<string, int>();
        ints.TryAdd("handSize", handSize);
        //you can only register one thing of each type
        ManagerManager.register(ints);
        ManagerManager.register(logger);
        ManagerManager.register(random);
        ManagerManager.register(UImanager);
        ManagerManager.registerDependency(() => new EnemyManager());
        ManagerManager.registerDependency(() => new CombatSystem());
        ManagerManager.registerDependency(() => new TurnSystem(10));
        ManagerManager.registerDependency(() => new GameManager());
        ManagerManager.registerDependency(() => new Player(10, 0, ""));
        ManagerManager.registerDependency(() => new CardManager());
        ManagerManager.registerDependency(() => allCards);
        ManagerManager.registerDependency(() => allEnemys);

        foreach (Func<object> manager in ManagerManager.managers)
        {
            ((IManager)manager()).Awake();
            ((IManager)manager()).Start();
        }
    }
    private void Update()
    {
        foreach (Func<object> manager in ManagerManager.managers)
        {
            ((IManager)manager()).Update();
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
