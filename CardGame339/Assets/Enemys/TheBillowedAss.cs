using System;
public class TheBillowedAss : Enemy
{
    CombatSystem combatSystem = ManagerManager.Resolve<CombatSystem>();
    IDialog dialogSys = ManagerManager.Resolve<IDialog>();
    EnemyManager enemyManager = ManagerManager.Resolve<EnemyManager>();
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "enemyID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int enemyID = 1;

    public override int Attack { get; set; } = 1;
    public override ValueHolder<int> HP { get; set; } = 5;
    public IRandom random = ManagerManager.Resolve<IRandom>();

    public override void DoAction(Player player, Enemy enemy)
    {

        IRandom random = ManagerManager.Resolve<IRandom>();
        int chooseAction = random.RandomNumber(3);
        if (chooseAction == 0)
        {
            combatSystem.DealDamageToPlayer(player, enemy);
        }

        if (chooseAction == 1)
        {
            combatSystem.GenerateEnemyShield(enemy);
        }

        if (chooseAction == 2)
        {
            dialogSys.EnemyTalk(enemy, enemyManager.enemyTaunts[random.RandomNumber(enemyManager.enemyTaunts.Count)]);
        }
    }

}
