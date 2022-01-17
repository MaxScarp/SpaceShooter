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

        public bool IsAlive;

        public Player() : base("Assets/player_ship.png")
        {
            speed = 455.0f;

            shot = false;
            shootOffset = new Vector2(sprite.pivot.X + 10.0f, sprite.pivot.Y - 10.0f);

            IsAlive = true;
        }

        public void Input()
        {
            if(IsAlive)
            {
                MovementInput();
                ShootInput();
            }
        }

        public override void Update()
        {
            if(IsAlive)
            {
                Move();
                base.Update();
            }
        }

        public override void Draw()
        {
            if(IsAlive)
            {
                base.Draw();
            }
        }

        protected override void Shoot()
        {
            PlayerBullet bullet = BulletManager.GetFreePlayerBullet();
            if(bullet != null)
            {
                bullet.Shoot(Position + shootOffset);
            }
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
    }
}
