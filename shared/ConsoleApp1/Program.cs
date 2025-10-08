// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

IGameLogger logger=new ConsoleGameLogger();
EnemyManager enemyManager = new EnemyManager(logger);
logger.Info("Hello");
enemyManager.SetUpEnemies();
EnemyBehavior.TakeTurn(enemyManager.enemies[0]);