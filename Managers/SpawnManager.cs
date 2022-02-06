using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class SpawnManager
    {
        private static int enemyNumber;
        private static Queue<Enemy> enemies;
        
        private static float nextSpawn;
        private static bool isStopped;

        public static void Init()
        {
            enemyNumber = 10;

            enemies = new Queue<Enemy>(enemyNumber);

            for (int i = 0; i < enemyNumber; i++)
            {
                enemies.Enqueue(new EnemyBase());
            }

            nextSpawn = RandomGenerator.GetRandomInt(1, 3);

            isStopped = false;
        }

        public static void Update()
        {
            if (!isStopped)
            {
                nextSpawn -= Game.Window.DeltaTime;

                if (nextSpawn <= 0)
                {
                    nextSpawn = RandomGenerator.GetRandomInt(1, 3);
                    SpawnEnemy();
                } 
            }
        }

        private static void SpawnEnemy()
        {
            if(enemies.Count > 0)
            {
                Enemy enemy = enemies.Dequeue();
                enemy.IsActive = true;
                enemy.Reset();

                enemy.Position = new Vector2(Game.Window.Width + enemy.Pivot.X, RandomGenerator.GetRandomInt((int)enemy.Pivot.Y, Game.Window.Height - (int)enemy.Pivot.Y));
            }
        }

        public static void RestoreEnemy(Enemy enemy)
        {
            enemy.IsActive = false;
            enemies.Enqueue(enemy);
        }

        public static void StopSpawning()
        {
            isStopped = true;
        }

        public static void SpawnBoss()
        {
            EnemyBoss boss = new EnemyBoss();
            boss.IsActive = true;
            boss.Reset();

            boss.Position = new Vector2(Game.Window.Width + boss.HalfWidth, Game.Window.Height * 0.5f);
        }
    }
}
