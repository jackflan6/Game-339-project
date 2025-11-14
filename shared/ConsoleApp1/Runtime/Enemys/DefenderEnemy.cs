using System;
public class DefenderEnemy : Enemy
{
    readonly CombatSystem combatSystem;
    readonly IDialog dialogSys;
    readonly EnemyManager enemyManager;
    readonly IRandom random;
    public override ValueHolder<int> dropCurrency { get; } = 5;
    public override ValueHolder<int> dropBossCurrency { get; } = 0;
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "enemyID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int enemyID = 3;
    
    #if !NOT_UNITY
    public DefenderEnemy()
    {
         combatSystem = ManagerManager.Resolve<CombatSystem>();
         dialogSys = ManagerManager.Resolve<IDialog>();
         enemyManager = ManagerManager.Resolve<EnemyManager>();
         random = ManagerManager.Resolve<IRandom>();
         
    }
    #endif

    public DefenderEnemy(CombatSystem combatSystem, IDialog iDialog, EnemyManager enemyManager, IRandom rand)
    {
        this.combatSystem = combatSystem;
        dialogSys = iDialog;
        this.enemyManager = enemyManager;
        random = rand;
    }

    public override int Attack { get; set; } = 0;

    public override int Defense { get; set; } = 4;
    public override int burnAttackDamage { get; } = 0;
    public override ValueHolder<int> currentShield { get; set; } = 0;
    public override ValueHolder<int> HP { get; set; } = 5;

    public override void DoAction(Player player, Enemy enemy)
    {
        combatSystem.GenerateEnemyShield(enemy);
    }

}
