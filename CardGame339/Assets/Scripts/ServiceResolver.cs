using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;


public class ServiceResolver : MonoBehaviour
{
    public ServiceResolver(IGameLogger logger)
    {
        this.logger = logger;
    }
    public IGameLogger logger;
    public IRandom random;
    public int handSize = 3;
    public Dictionary<string,int> ints;

    public List<Card> allCards;
    public UIManager UImanager = null;
    private void Start()
    {
        ints = new Dictionary<string, int>();
        ints.TryAdd("handSize",handSize);
        //you can only register one thing of each type
        ManagerManager.register(ints);
        ManagerManager.register(logger);
        ManagerManager.register(random);
        ManagerManager.register(UImanager);
        ManagerManager.register(allCards);
        ManagerManager.register(new EnemyManager());
        ManagerManager.register(new CombatSystem());
        ManagerManager.register(new TurnSystem(10));
        ManagerManager.register(new GameManager());
        ManagerManager.register(new Player(10, 0, ""));
        ManagerManager.register(new CardManager());
        foreach (IManager manager in ManagerManager.managers)
        {
            manager.Awake();
            manager.Start();
        }
    }
    private void Update()
    {
        foreach (IManager manager in ManagerManager.managers)
        {
            manager.Update();
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
