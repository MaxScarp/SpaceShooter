using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    class PlayerBullet : Bullet
    {
        public PlayerBullet() : base("blueLaser")
        {
            RigidBody.Type = RigidBodyType.PlayerBullet;
            RigidBody.Collider = CollidersFactory.CreateBoxFor(this);
            RigidBody.AddCollisionType(RigidBodyType.Enemy);

            speed = 1075.13f;

            damage = 25;
        }

        public override void Update()
        {
            if (IsActive)
            {
                if (Position.X - sprite.pivot.X > Game.Window.Width)
                {
                    BulletManager.RestoreBullet(this);
                }
            }
        }

        public override void OnCollide(GameObject other)
        {
            Enemy enemy = ((Enemy)other);
            enemy.AddDamage(damage);
            BulletManager.RestoreBullet(this);
        }
    }
}
