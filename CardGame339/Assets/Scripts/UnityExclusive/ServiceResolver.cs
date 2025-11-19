using System;
using System.Collections.Generic;
using ConsoleApp1;
using Unity.VisualScripting;
using UnityEngine;


public class ServiceResolver : MonoBehaviour
{
    public int handSize = 3;
    public int maxHandSize = 3;
    public int maxMana;
   // public ValueHolder<int> playerHP;
    public string playerName;

    //The logic for these two list are just to set up the enemys.
    //They will eventualy need to be removed when the rest of the logic is created
    public List<GameObject> allCardsPrefabs;
    public List<GameObject> allEnemyPrefabs;
    public ServiceResolver Instance;

    public UIManager UImanager;
    public GameObjectManager gameObjectManager;
    public UnityDialogSys unityDialog;
    public UnityEffects UnityEffects;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        print("Service Resolver is awake");
        //you can only register one thing of each type
        ManagerManager.reload();
        ManagerManager.register((IDialog)unityDialog);
        ManagerManager.register(UImanager);
        ManagerManager.register((IEffects)UnityEffects);
        ManagerManager.registerDependency(() => new EnemyManager());
        ManagerManager.registerDependency(() => new CombatSystem());
        ManagerManager.registerDependency(() => new TurnSystem(maxMana));
        ManagerManager.registerDependency(() => new GameManager());
        ManagerManager.registerDependency(() => new Player(ManagerManager.Resolve<CurrencyManager>().maxPlayerHP, 0, playerName));
        ManagerManager.registerDependency(() => new CardManager(handSize,maxHandSize));
        ManagerManager.registerDependency(()=> unityDialog);
        

        List<Card> allCards = new List<Card>();
        foreach (GameObject gam in allCardsPrefabs)
        {
            allCards.Add((Card)Activator.CreateInstance(ManagerManager.Resolve<Inventory>().GetAllCardIDs.Value[gam.GetComponent<SelectableCard>().cardID])) ;
        }
        //ManagerManager.Resolve<CardManager>().AllCards = allCards;


        foreach (GameObject gam in allEnemyPrefabs)
        {
            ManagerManager.Resolve<EnemyManager>().enemiesToCreate.Add(ManagerManager.Resolve<EnemyManager>().GetAllEnemyIDs.Value[gam.GetComponent<SelectableEnemy>().enemyID]);
        }



        foreach (Func<object> manager in ManagerManager.managers)
        {
            ((IManager)manager()).Awake();
        }
    }

    private void Start()
    {
        foreach (Func<object> manager in ManagerManager.managers)
        {
            var man = (IManager)manager();
            print(man.GetType() + "has started");
            man.Start();
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


