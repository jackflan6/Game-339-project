namespace TestProject1;

public class ConsoleGameLogger : IGameLogger
{
    public void Info(string message)
    {
        Console.WriteLine(message);
    }

    public void Warning(string message)
    {
        Console.WriteLine(message);
    }

    public void Error(string message)
    {
        Console.WriteLine(message);
    }

    public void print(string message)
    {
        Console.WriteLine(message);
    }
}