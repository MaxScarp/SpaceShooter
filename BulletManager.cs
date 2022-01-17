﻿using Aiv.Fast2D;
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
        private static Queue<Bullet>[] bullets;
        private static List<Bullet>[] activeBullets;

        public static void Init(int _playerBulletNum, int _enemyBulletNum)
        {
            int playerBulletNum = _playerBulletNum;
            int enemyBulletNum = _enemyBulletNum;

            bullets = new Queue<Bullet>[(int)BulletType.LAST];

            for (int i = 0; i < bullets.Length; i++)
            {
                switch (i)
                {
                    case (int)BulletType.PlayerBullet:
                        bullets[i] = new Queue<Bullet>(playerBulletNum);
                        for (int j = 0; j < playerBulletNum; j++)
                        {
                            bullets[i].Enqueue(new PlayerBullet());
                        }
                        break;
                    case (int)BulletType.EnemyBullet:
                        bullets[i] = new Queue<Bullet>(enemyBulletNum);
                        for (int j = 0; j < enemyBulletNum; j++)
                        {
                            bullets[i].Enqueue(new EnemyBullet());
                        }
                        break;
                    default:
                        Console.WriteLine("Creation of bullet Queue failed!");
                        bullets[i].Enqueue(null);
                        break;
                }
            }

            activeBullets = new List<Bullet>[(int)BulletType.LAST];
            for (int i = 0; i < activeBullets.Length; i++)
            {
                activeBullets[i] = new List<Bullet>();
            }
        }

        public static void Update()
        {
            for (int i = 0; i < activeBullets.Length; i++)
            {
                for (int j = 0; j < activeBullets[i].Count; j++)
                {
                    activeBullets[i][j].Update();
                }
            }
        }

        public static void Draw()
        {
            for (int i = 0; i < activeBullets.Length; i++)
            {
                for (int j = 0; j < activeBullets[i].Count; j++)
                {
                    activeBullets[i][j].Draw();
                }
            }
        }

        public static Bullet GetBullet(BulletType type)
        {
            int index = (int)type;

            if(bullets[index].Count > 0)
            {
                Bullet bullet = bullets[index].Dequeue();
                activeBullets[index].Add(bullet);

                return bullet;
            }

            return null;
        }

        public static void RestoreBullet(Bullet bullet)
        {
            int index = bullet is PlayerBullet ? (int)BulletType.PlayerBullet : (int)BulletType.EnemyBullet;

            activeBullets[index].Remove(bullet);
            bullets[index].Enqueue(bullet);
        }
    }
}