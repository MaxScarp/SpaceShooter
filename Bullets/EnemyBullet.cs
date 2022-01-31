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
            sprite.FlipX = true;

            speed = -950.13f;
            velocity.X = speed;

            RigidBody = new RigidBody(this);
            RigidBody.Collider = CollidersFactory.CreateCircleColliderFor(this);
        }

        public override void Update()
        {
            base.Update();
            if (Position.X + sprite.pivot.X < 0)
            {
                BulletManager.RestoreBullet(this);
            }
        }
    }
}
