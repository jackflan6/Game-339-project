using System;
using System.Collections.Generic;
using System.Linq;

public class EnemyManager : IManager
{
    public List<Type> enemiesToCreate = new List<Type>();
    public List<Enemy> enemies = new List<Enemy>();
    public event Action<Enemy> enemyAdded;
    public event Action<Enemy> enemyRemoved;

    public void SetUpEnemies()
    {
        foreach (Type enemy in enemiesToCreate)
        {
            CreateEnemy(enemy);
        }
    }

    public void CreateEnemy(Type enemy)
    {
        Enemy enemyObj = (Enemy)Activator.CreateInstance(enemy);
        enemies.Add(enemyObj);
        if (enemyAdded != null)
        {
            enemyAdded.Invoke(enemyObj);
        } else
        {
            ManagerManager.Resolve<IGameLogger>().print("GameObject was not created");
        }
        ManagerManager.Resolve<IGameLogger>().print("created " + enemy.Name);
    }

    public void DestroyEnemy(Enemy enemy)
    {
        if (enemyRemoved != null) enemyRemoved.Invoke(enemy);
        enemies.Remove(enemy);
    }
    public Lazy<Dictionary<int, Type>> GetAllEnemyIDs = new Lazy<Dictionary<int, Type>>(() =>
    {
        Dictionary<int, Type> EnemyIDs = new Dictionary<int, Type>();
        IEnumerable<Type> c = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsSubclassOf(typeof(Enemy)));
        foreach (Type t in c)
        {
            EnemyIDs.TryAdd((int)t.GetField("enemyID").GetValue(null), t);
        }
        return EnemyIDs;
    });
}