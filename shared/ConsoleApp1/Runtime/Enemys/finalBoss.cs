using System;
public class finalBoss : Enemy
{
    readonly CombatSystem combatSystem;
    readonly IDialog dialogSys;
    readonly EnemyManager enemyManager;
    readonly IRandom random;
    public override ValueHolder<int> dropCurrency { get; } = 5;

    private int processionOfActions;
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "enemyID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int enemyID = 12;
    
    #if !NOT_UNITY
    public finalBoss()
    {
         combatSystem = ManagerManager.Resolve<CombatSystem>();
         dialogSys = ManagerManager.Resolve<IDialog>();
         enemyManager = ManagerManager.Resolve<EnemyManager>();
         random = ManagerManager.Resolve<IRandom>();
         
    }
    #endif

    public finalBoss(CombatSystem combatSystem, IDialog iDialog, EnemyManager enemyManager, IRandom rand)
    {
        this.combatSystem = combatSystem;
        dialogSys = iDialog;
        this.enemyManager = enemyManager;
        random = rand;
    }

    public override int Attack { get; set; } = 5;
    public override int Defense { get; set; } = 3;
    public override int burnAttackDamage { get; } = 4;
    public override ValueHolder<int> currentShield { get; set; } = 0;
    public override ValueHolder<int> HP { get; set; } = 50;

    public override void DoAction(Player player, Enemy enemy)
    {
        
        combatSystem.GenerateEnemyShield(enemy);
        combatSystem.DealDamageToPlayer(player, enemy);
        combatSystem.ApplyBurnDamageToPlayer(player, enemy);
    }

}
