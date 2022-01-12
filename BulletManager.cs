using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    static class BulletManager
    {
        private static int playerBulletNum;
        private static int enemyBulletNum;
        private static Queue<PlayerBullet> playerBullets;
        private static List<PlayerBullet> activePlayerBullets;
        private static Queue<EnemyBullet> enemyBullets;
        private static List<EnemyBullet> activeEnemyBullets;

        public static void Init(int _playerBulletNum, int _enemyBulletNum)
        {
            playerBulletNum = _playerBulletNum;
            enemyBulletNum = _enemyBulletNum;

            playerBullets = new Queue<PlayerBullet>(playerBulletNum);
            enemyBullets = new Queue<EnemyBullet>(enemyBulletNum);

            for (int i = 0; i < playerBulletNum; i++)
            {
                playerBullets.Enqueue(new PlayerBullet());
            }

            for (int i = 0; i < enemyBulletNum; i++)
            {
                enemyBullets.Enqueue(new EnemyBullet());
            }

            activePlayerBullets = new List<PlayerBullet>();
            activeEnemyBullets = new List<EnemyBullet>();
        }

        public static void Update()
        {
            for (int i = 0; i < activePlayerBullets.Count; i++)
            {
                activePlayerBullets[i].Update();
            }
            for (int i = 0; i < activeEnemyBullets.Count; i++)
            {
                activeEnemyBullets[i].Update();
            }
        }

        public static void Draw()
        {
            for (int i = 0; i < activePlayerBullets.Count; i++)
            {
                activePlayerBullets[i].Draw();
            }
            for (int i = 0; i < activeEnemyBullets.Count; i++)
            {
                activeEnemyBullets[i].Draw();
            }
        }

        public static PlayerBullet GetFreePlayerBullet()
        {
            if(playerBullets.Count > 0)
            {
                PlayerBullet bullet = playerBullets.Dequeue();
                activePlayerBullets.Add(bullet);

                return bullet;
            }
            return null;
        }

        public static EnemyBullet GetFreeEnemyBullet()
        {
            if (enemyBullets.Count > 0)
            {
                EnemyBullet bullet = enemyBullets.Dequeue();
                activeEnemyBullets.Add(bullet);

                return bullet;
            }
            return null;
        }

        public static void RestorePlayerBullet(PlayerBullet bullet)
        {
            activePlayerBullets.Remove(bullet);
            playerBullets.Enqueue(bullet);
        }

        public static void RestoreEnemyBullet(EnemyBullet bullet)
        {
            activeEnemyBullets.Remove(bullet);
            enemyBullets.Enqueue(bullet);
        }
    }
}