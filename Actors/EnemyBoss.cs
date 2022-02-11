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
        private float timeToChangeWeapon;

        private bool isVelocityChanged;

        public EnemyBoss() : base("boss")
        {
            Type = EnemyType.Boss;

            posOffset = 45;

            RigidBody.Collider = CollidersFactory.CreateCircleFor(this, false);
            CompoundCollider compound = new CompoundCollider(RigidBody, RigidBody.Collider);

            BoxCollider box01 = new BoxCollider(RigidBody, (int)(HalfWidth + 100), (int)(HalfHeight * 2 - 40));
            box01.Offset = new Vector2(40, 0);
            compound.AddCollider(box01);

            BoxCollider box02 = new BoxCollider(RigidBody, (int)(HalfWidth * 2), 25);
            box02.Offset = new Vector2(0.0f, 75.0f);
            compound.AddCollider(box02);

            BoxCollider box03 = new BoxCollider(RigidBody, 80, 20);
            box03.Offset = new Vector2(68.0f, 90.0f);
            compound.AddCollider(box03);

            RigidBody.Collider.Offset = compound.Offset;
            RigidBody.Collider = compound;

            speed = -150.0f;
            RigidBody.Velocity.X = speed;

            shootOffset = new Vector2(-HalfWidth, HalfHeight * 0.5f);
            maxEnergy = 2500;

            tripleShootAngle = MathHelper.DegreesToRadians(15.0f);
            nextShoot = RandomGenerator.GetRandomInt(0, 3);
            timeToChangeWeapon = 10.0f;

            isVelocityChanged = false;

            Points = 500;
        }

        public override void Update()
        {
            if(IsActive)
            {
                nextShoot -= Game.DeltaTime;
                timeToChangeWeapon -= Game.DeltaTime;

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
            if (timeToChangeWeapon <= 0.0f)
            {
                timeToChangeWeapon = RandomGenerator.GetRandomInt(4, 8);
                NextWeapon();
            }

            if (nextShoot <= 0.0f)
            {
                nextShoot = RandomGenerator.GetRandomFloat();
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
