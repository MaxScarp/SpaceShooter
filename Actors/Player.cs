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
        private bool shot;

        public Player() : base("player")
        {
            speed = 455.0f;

            shot = false;
            bulletType = BulletType.PlayerBullet;
            shootOffset = new Vector2(sprite.pivot.X + 10.0f, sprite.pivot.Y - 10.0f);

            RigidBody = new RigidBody(this);
            RigidBody.Collider = CollidersFactory.CreateCircleColliderFor(this);

            IsActive = true;

            UpdateManager.AddItem(this);
            DrawManager.AddItem(this);
        }

        public void Input()
        {
            MovementInput();
            ShootInput();
        }

        public override void Update()
        {
            Move();
            base.Update();
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
                velocity.X = speed;
            }
            else if (Game.Window.GetKey(KeyCode.A) && (Position.X - sprite.Width * 0.5f >= 0))
            {
                velocity.X = -speed;
            }
            else
            {
                velocity.X = 0.0f;
            }

            if (Game.Window.GetKey(KeyCode.W) && (Position.Y - sprite.Height * 0.5f >= 0))
            {
                velocity.Y = -speed;
            }
            else if (Game.Window.GetKey(KeyCode.S) && (Position.Y + sprite.Height * 0.5f < Game.Window.Height))
            {
                velocity.Y = speed;
            }
            else
            {
                velocity.Y = 0.0f;
            }
        }

        private void Move()
        {
            if (velocity.X != 0 || velocity.Y != 0)
            {
                velocity = velocity.Normalized() * speed;
            }
        }

        public override void OnCollide(GameObject gameObject)
        {
            //throw new NotImplementedException();
        }
    }
}
