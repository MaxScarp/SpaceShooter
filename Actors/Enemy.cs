using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    enum EnemyType { Base, Red, Boss, LAST }

    abstract class Enemy : Actor
    {
        protected float nextShoot;

        public int Points { get; protected set; }

        public EnemyType Type { get; protected set; }

        public Enemy(string textureName) : base(textureName)
        {
            sprite.FlipX = true;
            RigidBody.Type = RigidBodyType.Enemy;
            bulletType = BulletType.EnemyBullet;
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
