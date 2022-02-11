using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class Player : Actor
    {
        private ProgressBar energyBar;

        private bool shot;

        public override int Energy { get => base.Energy; set { base.Energy = value; energyBar.Scale((float)value / maxEnergy); } }

        public Player(int id = 0) : base("player")
        {
            RigidBody.Type = RigidBodyType.Player;
            RigidBody.Collider = CollidersFactory.CreateBoxFor(this);
            RigidBody.AddCollisionType(RigidBodyType.Enemy);

            speed = 455.0f;
            tripleShootAngle = MathHelper.DegreesToRadians(15.0f);
            shot = false;
            bulletType = BulletType.PlayerBullet;
            shootOffset = new Vector2(sprite.pivot.X + 10.0f, sprite.pivot.Y - 10.0f);

            energyBar = new ProgressBar("frameBar", "bar", new Vector2(4.0f, 4.0f));
            energyBar.Position = new Vector2(60.0f, 50.0f);

            IsActive = true;
            
            maxEnergy = 100;
            Reset();
        }

        public void Input()
        {
            MovementInput();
            ShootInput();
        }

        public override void Update()
        {
            Move();
        }

        private void ShootInput()
        {
            if (Game.Window.GetKey(KeyCode.Space))
            {
                if (!shot)
                {
                    shot = true;
                    Shoot();
                }
            }
            else
            {
                shot = false;
            }
        }

        private void MovementInput()
        {
            if (Game.Window.GetKey(KeyCode.D) && (Position.X + sprite.Width * 0.5f < Game.Window.Width))
            {
                RigidBody.Velocity.X = speed;
            }
            else if (Game.Window.GetKey(KeyCode.A) && (Position.X - sprite.Width * 0.5f >= 0))
            {
                RigidBody.Velocity.X = -speed;
            }
            else
            {
                RigidBody.Velocity.X = 0.0f;
            }

            if (Game.Window.GetKey(KeyCode.W) && (Position.Y - sprite.Height * 0.5f >= 0))
            {
                RigidBody.Velocity.Y = -speed;
            }
            else if (Game.Window.GetKey(KeyCode.S) && (Position.Y + sprite.Height * 0.5f < Game.Window.Height))
            {
                RigidBody.Velocity.Y = speed;
            }
            else
            {
                RigidBody.Velocity.Y = 0.0f;
            }
        }

        private void Move()
        {
            if (RigidBody.Velocity.X != 0 || RigidBody.Velocity.Y != 0)
            {
                RigidBody.Velocity = RigidBody.Velocity.Normalized() * speed;
            }
        }

        public override void OnCollide(GameObject other)
        {
            SpawnManager.RestoreEnemy((Enemy)other);
            AddDamage(100);
        }
    }
}
