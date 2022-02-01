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
        private static List<Enemy> activeEnemies;

        private static float nextSpawn;

        public static void Init()
        {
            enemyNumber = 10;

            enemies = new Queue<Enemy>(enemyNumber);
            activeEnemies = new List<Enemy>();

            for (int i = 0; i < enemyNumber; i++)
            {
                enemies.Enqueue(new Enemy());
            }

            nextSpawn = RandomGenerator.GetRandomInt(1, 3);
        }

        public static void Update()
        {
            nextSpawn -= Game.Window.DeltaTime;

            if(nextSpawn <= 0)
            {
                nextSpawn = RandomGenerator.GetRandomInt(1, 3);
                SpawnEnemy();
            }
        }

        private static void SpawnEnemy()
        {
            if(enemies.Count > 0)
            {
                Enemy enemy = enemies.Dequeue();
                enemy.IsActive = true;
                activeEnemies.Add(enemy);
                
                enemy.Position = new Vector2(Game.Window.Width + enemy.Pivot.X, RandomGenerator.GetRandomInt((int)enemy.Pivot.Y, Game.Window.Height - (int)enemy.Pivot.Y));

                UpdateManager.AddItem(enemy);
                DrawManager.AddItem(enemy);
            }
        }

        public static void RestoreEnemy(Enemy enemy)
        {
            enemy.IsActive = false;
            activeEnemies.Remove(enemy);
            enemies.Enqueue(enemy);

            UpdateManager.RemoveItem(enemy);
            DrawManager.RemoveItem(enemy);
        }
    }
}
