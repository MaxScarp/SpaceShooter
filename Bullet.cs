using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    class Bullet
    {
        private Texture texture;
        private Sprite sprite;

        public Vector2 velocity;
        private float speed;

        public bool isAlive;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }
        public float Speed { get { return speed; } }

        public Bullet()
        {
            texture = new Texture("Assets/blueLaser.png");
            sprite = new Sprite(texture.Width, texture.Height);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);

            speed = 875.13f;

            isAlive = false;
        }

        public void Update()
        {
            if(isAlive)
            {
                Move();
            }
        }
        public void Draw()
        {
            if(isAlive)
            {
                sprite.DrawTexture(texture);
            }
        }
        
        private void Move()
        {
            if (velocity.X != 0 || velocity.Y != 0)
            {
                velocity = velocity.Normalized() * speed;
            }
            Position += velocity * Game.DeltaTime;

            if (Position.X - sprite.Width * 0.5f > Game.Window.Width)
            {
                isAlive = false;
            }
        }
    }
}
