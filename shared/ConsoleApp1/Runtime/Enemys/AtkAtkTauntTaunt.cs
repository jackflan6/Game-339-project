using System;
using System.Collections.Generic;

public class AtkAtkTauntTaunt : Enemy
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
    public static int enemyID = 9;
    
    #if !NOT_UNITY
    public AtkAtkTauntTaunt()
    {
         combatSystem = ManagerManager.Resolve<CombatSystem>();
         dialogSys = ManagerManager.Resolve<IDialog>();
         enemyManager = ManagerManager.Resolve<EnemyManager>();
         random = ManagerManager.Resolve<IRandom>();
         
    }
    #endif

    public AtkAtkTauntTaunt(CombatSystem combatSystem, IDialog iDialog, EnemyManager enemyManager, IRandom rand)
    {
        this.combatSystem = combatSystem;
        dialogSys = iDialog;
        this.enemyManager = enemyManager;
        random = rand;
    }

    public override int Attack { get; set; } = 5;
    public override int Defense { get; set; } = 5;
    public override ValueHolder<int> dropCurrency { get; } = 5;
    public override int burnAttackDamage { get; } = 0;
    public override ValueHolder<int> HP { get; set; } = 5;

    public override void DoAction(Player player, Enemy enemy)
    {
        if (processionOfActions == 0)
        {
            combatSystem.DealDamageToPlayer(player, enemy);
        }
        else if (processionOfActions == 1)
        {
            combatSystem.DealDamageToPlayer(player, enemy);
        }
        else if (processionOfActions == 2)
        {
            dialogSys.EnemyTalk(enemy, enemyManager.enemyTaunts[random.RandomNumber(enemyManager.enemyTaunts.Count)]);
        }
        else if (processionOfActions==3)
        {
            dialogSys.EnemyTalk(enemy, enemyManager.enemyTaunts[random.RandomNumber(enemyManager.enemyTaunts.Count)]);
        }
        

        processionOfActions++;
        if(processionOfActions>3)
        {
            processionOfActions = 0;
        }
    }

}
