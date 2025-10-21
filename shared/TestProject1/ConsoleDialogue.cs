namespace TestProject1;

public class ConsoleDialogue : IDialog
{
    public void EnemyTalk(Enemy enemy, string message)
    {
        Console.WriteLine(message);
    }
}