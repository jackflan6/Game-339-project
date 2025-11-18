using ConsoleApp1;

namespace TestProject1;

public class TestEffects : IEffects
{
    public void ShowBurn(Enemy enemy)
    {
        Console.WriteLine("Ahh! I'm on fire!");
    }

    public void ShowDamage(Enemy enemy)
    {
        Console.WriteLine("Ouch! I've taken damage!");
    }

    public void DisplayBurnIcon(Enemy enemy)
    {
        Console.WriteLine("The burn icon has been assessed!");
    }
}