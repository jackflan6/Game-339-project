using System;
public class TheBillowedAss : Enemy
{
    //::::Important::::
    //It is nessasary to have every card have a static int for its ID.
    //This need to be called "enemyID" and reflected in the selectableCard object.
    //It is not forced by the interface so you just need to remember
    public static int enemyID = 1;

    public override int Attack { get; set; } = 1;
    public override int HP { get; set; } = 5;
    public IRandom random = ManagerManager.Resolve<IRandom>();

    public override void DoAction(Player player, Enemy enemy)
    {

        int chooseAction = random.RandomNumber(2);
        if (chooseAction == 0)
        {
            ManagerManager.Resolve<CombatSystem>().DealDamageToPlayer(player, enemy);
        }

        if (chooseAction == 1)
        {
            ManagerManager.Resolve<CombatSystem>().GenerateEnemyShield(enemy);
        }
    }

}
