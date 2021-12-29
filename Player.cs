using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class Player
    {
        private Texture texture;
        private Sprite sprite;

        private Vector2 velocity;
        private float speed;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }

        private bool shot;

        public bool IsAlive;

        public Player()
        {
            texture = new Texture("Assets/player_ship.png");
            sprite = new Sprite(texture.Width, texture.Height);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);

            speed = 375.0f;

            shot = false;

            IsAlive = true;
        }

        public void Input()
        {
            if(IsAlive)
            {
                MovementInput();
                Shoot();
            }
        }
        public void Update()
        {
            if(IsAlive)
            {
                Move();
            }
            BulletManager.Update();
        }
        public void Draw()
        {
            if(IsAlive)
            {
                sprite.DrawTexture(texture);
            }
            BulletManager.Draw();
        }

        private void Shoot()
        {
            if(Game.Window.GetKey(KeyCode.Space))
            {
                if(!shot)
                {
                    shot = true;

                    Bullet bullet = BulletManager.GetFreeBullet();
                    if(bullet != null)
                    {
                        bullet.isAlive = true;
                        bullet.Position = Position;
                        bullet.velocity.X = bullet.Speed;
                    }
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
            Position += velocity * Game.DeltaTime;
        }
    }
}
