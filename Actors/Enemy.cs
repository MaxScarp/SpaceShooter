using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class Enemy : Actor
    {
        private float nextShoot;

        public Enemy() : base("enemy")
        {
            sprite.FlipX = true;

            speed = -475.0f;
            RigidBody.Velocity.X = speed;

            bulletType = BulletType.EnemyBullet;
            shootOffset = new Vector2(-Pivot.X, Pivot.Y * 0.5f);
            nextShoot = RandomGenerator.GetRandomFloat() + 0.3f;
        }

        public override void Update()
        {
            if (IsActive)
            {
                if (Position.X + Pivot.X < 0)
                {
                    SpawnManager.RestoreEnemy(this);
                }

                nextShoot -= Game.Window.DeltaTime;

                if (nextShoot <= 0)
                {
                    nextShoot = RandomGenerator.GetRandomFloat() + 0.3f;
                    Shoot();
                } 
            }
        }

        protected override void OnDie()
        {
            SpawnManager.RestoreEnemy(this);
        }
    }
}
