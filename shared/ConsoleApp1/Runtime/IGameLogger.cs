using System;

public interface IGameLogger
{
    void Info(string message);
    void Warning(string message);
    void Error(string message);
    void print(string message);
}