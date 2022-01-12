using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class EnemyBullet
    {
        private Sprite sprite;
        private Texture texture;

        private Vector2 velocity;
        private float speed;

        public Vector2 Position { get {return sprite.position; } set {sprite.position = value; } }

        public EnemyBullet()
        {
            texture = new Texture("Assets/beams.png");
            sprite = new Sprite(74, 46);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);
            sprite.FlipX = true;

            speed = -775.13f;
            velocity.X = speed;
        }

        public void Update()
        {
            Move();
        }

        public void Draw()
        {
            sprite.DrawTexture(texture, 156, 227, (int)sprite.Width, (int)sprite.Height);
        }

        private void Move()
        {
            Position += velocity * Game.Window.DeltaTime;

            if (Position.X + sprite.pivot.X < 0)
            {
                BulletManager.RestoreEnemyBullet(this);
            }
        }

        public void Shoot(Vector2 shootPos)
        {
            Position = shootPos;
        }
    }
}
