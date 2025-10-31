using System;
public class shieldAttackBoss : Enemy
{
    readonly CombatSystem combatSystem;
    readonly IDialog dialogSys;
    readonly EnemyManager enemyManager;
    readonly IRandom random;

    private int processionOfActions;
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "enemyID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int enemyID = 0;
    
    #if !NOT_UNITY
    public shieldAttackBoss()
    {
         combatSystem = ManagerManager.Resolve<CombatSystem>();
         dialogSys = ManagerManager.Resolve<IDialog>();
         enemyManager = ManagerManager.Resolve<EnemyManager>();
         random = ManagerManager.Resolve<IRandom>();
         
    }
    #endif

    public shieldAttackBoss(CombatSystem combatSystem, IDialog iDialog, EnemyManager enemyManager, IRandom rand)
    {
        this.combatSystem = combatSystem;
        dialogSys = iDialog;
        this.enemyManager = enemyManager;
        random = rand;
    }

    public override int Attack { get; set; } = 7;
    public override int Defense { get; set; } = 10;
    public override int burnAttackDamage { get; } = 0;
    public override ValueHolder<int> HP { get; set; } = 40;

    public override void DoAction(Player player, Enemy enemy)
    {
        
        combatSystem.GenerateEnemyShield(enemy);
        combatSystem.DealDamageToPlayer(player, enemy);
        
    }

}
