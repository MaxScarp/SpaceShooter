using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class EnemyBoss : Enemy
    {
        private int posOffset;

        private float nextNormalShoot;
        private int nextSuperShootCounter;
        private uint superShootNumber;

        private bool isVelocityChanged;

        public EnemyBoss() : base("boss")
        {
            posOffset = 45;

            RigidBody.Collider = CollidersFactory.CreateBoxFor(this);

            speed = -150.0f;
            RigidBody.Velocity.X = speed;

            shootOffset = new Vector2(-HalfWidth, HalfHeight * 0.5f);
            maxEnergy = 2500;

            nextNormalShoot = RandomGenerator.GetRandomInt(0, 3);
            nextSuperShootCounter = 0;
            superShootNumber = 4;

            isVelocityChanged = false;
        }

        public override void Update()
        {
            if(IsActive)
            {
                nextNormalShoot -= Game.DeltaTime;

                if(!isVelocityChanged && (Position.X <= Game.Window.Width - posOffset))
                {
                    Repositioning();
                }

                Move();
                ShootLogic();
            }
        }

        private void ShootLogic()
        {
            if(nextNormalShoot <= 0.0f)
            {
                ChangeWeapon(WeaponType.Default);
                nextNormalShoot = RandomGenerator.GetRandomFloat() + 0.62f;
                Shoot();
                nextSuperShootCounter++;
            }

            if(nextSuperShootCounter != 0 && nextSuperShootCounter % 10 == 0)
            {
                ChangeWeapon(WeaponType.Triple);
                Shoot();
            }
        }

        private void Move()
        {
            if (Position.Y - HalfHeight <= 0 || Position.Y + HalfHeight >= Game.Window.Height)
            {
                speed = -speed;
                RigidBody.Velocity.Y = speed;
            }
        }

        private void Repositioning()
        {
            isVelocityChanged = true;
            speed = 450.0f;
            RigidBody.Velocity = new Vector2(0.0f, speed);
        }
    }
}
