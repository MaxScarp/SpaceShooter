using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    abstract class Actor : GameObject
    {
        protected BulletType bulletType;
        protected Vector2 shootOffset;

        public Actor(string texturePath) : base(texturePath) { }

        protected virtual void Shoot()
        {
            Bullet bullet = BulletManager.GetBullet(bulletType);
            if (bullet != null)
            {
                bullet.Shoot(Position + shootOffset);
            }
        }
    }
}
