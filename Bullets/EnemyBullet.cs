using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    abstract class EnemyBullet : Bullet
    {
        public EnemyBullet(string textureName, int spriteWidth = 0, int spriteHeight = 0) : base(textureName, spriteWidth, spriteHeight)
        {
            RigidBody.Type = RigidBodyType.EnemyBullet;
            RigidBody.AddCollisionType(RigidBodyType.Player);

            sprite.FlipX = true;

            speed = -950.13f;
        }

        public override void Update()
        {
            if (IsActive)
            {
                if (Position.X + sprite.pivot.X < 0)
                {
                    BulletManager.RestoreBullet(this);
                }
            }
        }

        public override void OnCollide(GameObject other)
        {
            ((Player)other).AddDamage(damage);
            BulletManager.RestoreBullet(this);
        }
    }
}
