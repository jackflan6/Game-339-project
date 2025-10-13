using NUnit.Framework;
using System;
using System.Transactions;
using System.Collections.Generic;
using System.Collections.Concurrent;

public static class ManagerManager
{
    static ConcurrentDictionary<Type, Func<object>> m_register = new ConcurrentDictionary<Type, Func<object>>();
    public static List<Func<object>> managers = new List<Func<object>>();
    public static T Resolve<T>()
    {
        if (m_register.TryGetValue(typeof(T),out var ret))
        {
            return (T)ret();
        }

        throw new Exception($"There is yet to be a registration for {typeof(T)}");
    }


    public static void register<T>(T obj)
    {
        if (obj == null) { throw new Exception("Tried to register a null value"); }


        if (m_register.TryAdd(typeof(T), () => obj)) { return; }

        throw new Exception($"Already registered a {typeof(T)}");
    }

    public static void registerFactory<T>(Func<object> factory)
    {
        if (factory == null) throw new Exception("Tried to register a null value");

        if (m_register.TryAdd(typeof(T), factory)) return;

        throw new Exception($"Already registered a {typeof(T)}");
    }
    
    public static void registerDependency<T>(Func<T> obj)
    {
        if (obj == null) { throw new Exception("Tried to register a null value"); }

        Lazy<T> lazy = new Lazy<T>(obj);

        if (m_register.TryAdd(typeof(T), () => lazy.Value)) 
        {
            if (typeof(T).IsSubclassOf(typeof(IManager)))
            {
                managers.Add(() => lazy.Value);
            }
            return; 
        }

        throw new Exception($"Already registered a {typeof(T)}");
    }
}
