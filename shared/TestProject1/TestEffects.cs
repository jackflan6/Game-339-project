using ConsoleApp1;

namespace TestProject1;

public class TestEffects : IEffects
{
    public void ShowBurn(Enemy enemy)
    {
        Console.WriteLine("Ahh! I'm on fire!");
    }
}