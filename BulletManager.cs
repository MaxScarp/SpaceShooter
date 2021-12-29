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
        private static int bulletNum;
        private static Bullet[] bullets;

        public static void Init(int _bulletNum)
        {
            bulletNum = _bulletNum;
            bullets = new Bullet[bulletNum];

            for (int i = 0; i < bulletNum; i++)
            {
                bullets[i] = new Bullet();
            }
        }gewgewg

        public static void Update()dfegwgewgwe
        {
            for (int i = 0; i < bulletNum; i++)
            {
                bullets[i].Update();
            }vwevwe
        }
        public static void Draw()
        {
            for (int i = 0; i < bulletNum; i++)
            {
                bullets[i].Draw();
            }feavef
        }

        public static Bullet GetFreeBullet()
        {
            for (int i = 0; i < bulletNum; i++)
            {
                if (!bullets[i].isAlive)
                {
                    return bullets[i];
                }
            }

            return null;
        }
    }
}
