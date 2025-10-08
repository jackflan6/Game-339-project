namespace ConsoleApp1;

public interface IGameLogger
{
    void Info(string message);
    void Warning(string message);
    void Error(string message);
}