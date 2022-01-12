using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class Enemy
    {
        private Texture texture;
        private Sprite sprite;

        private Vector2 velocity;
        private float speed;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }
        public Vector2 Pivot { get { return sprite.pivot; } set { sprite.pivot = value; } }

        private Vector2 shootOffset;
        private float nextShoot;

        public Enemy()
        {
            texture = new Texture("Assets/enemy_ship.png");
            sprite = new Sprite(texture.Width, texture.Height);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);
            sprite.FlipX = true;

            speed = -315.0f;
            velocity.X = speed;

            shootOffset = new Vector2(-Pivot.X, Pivot.Y * 0.5f);
            nextShoot = RandomGenerator.GetRandomFloat() + 0.3f;
        }

        public void Update()
        {
            Position += velocity * Game.DeltaTime;
                
            if(Position.X + Pivot.X < 0)
            {
                SpawnManager.RestoreEnemy(this);
            }

            nextShoot -= Game.Window.DeltaTime;

            if(nextShoot <= 0)
            {
                nextShoot = RandomGenerator.GetRandomFloat() + 0.3f;
                Shoot();
            }
        }

        public void Draw()
        {
            sprite.DrawTexture(texture);
        }

        private void Shoot()
        {
            EnemyBullet bullet = BulletManager.GetFreeEnemyBullet();
            if (bullet != null)
            {
                bullet.Shoot(Position + shootOffset);
            }
        }
    }
}
