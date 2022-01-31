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

            speed = -515.0f;
            velocity.X = speed;

            bulletType = BulletType.EnemyBullet;
            shootOffset = new Vector2(-Pivot.X, Pivot.Y * 0.5f);
            nextShoot = RandomGenerator.GetRandomFloat() + 0.3f;

            RigidBody = new RigidBody(this);
            RigidBody.Collider = CollidersFactory.CreateCircleColliderFor(this);
        }

        public override void OnCollide(GameObject other)
        {
            if(other is PlayerBullet)
            {
                Console.WriteLine($"{GetType()} is colliding with {other.GetType()}");
            }
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
    }
}
