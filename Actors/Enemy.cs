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

        public Enemy() : base("Assets/enemy_ship.png")
        {
            sprite.FlipX = true;

            speed = -315.0f;
            velocity.X = speed;

            shootOffset = new Vector2(-Pivot.X, Pivot.Y * 0.5f);
            nextShoot = RandomGenerator.GetRandomFloat() + 0.3f;
        }

        public override void Update()
        {
            base.Update();
            
            if(Position.X + Pivot.X < 0)
            {
                SpawnManager.RestoreEnemy(this);
            }

            nextShoot -= Game.Window.DeltaTime;

            if(nextShoot <= 0)
            {
                nextShoot = RandomGenerator.GetRandomFloat() + 0.3f;
                Shoot();
            }
        }

        protected override void Shoot()
        {
            EnemyBullet bullet = BulletManager.GetFreeEnemyBullet();
            if (bullet != null)
            {
                bullet.Shoot(Position + shootOffset);
            }
        }
    }
}
