using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    class PlayerBullet
    {
        private Texture texture;
        private Sprite sprite;

        public Vector2 velocity;
        private float speed;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }

        public PlayerBullet()
        {
            texture = new Texture("Assets/blueLaser.png");
            sprite = new Sprite(texture.Width, texture.Height);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);

            speed = 875.13f;
            velocity.X = speed;
        }

        public void Update()
        {
            Move();
        }
        public void Draw()
        {
            sprite.DrawTexture(texture);
        }

        private void Move()
        {
            Position += velocity * Game.DeltaTime;

            if (Position.X - sprite.pivot.X > Game.Window.Width)
            {
                BulletManager.RestorePlayerBullet(this);
            }
        }

        public void Shoot(Vector2 shootPos)
        {
            Position = shootPos;
        }
    }
}
