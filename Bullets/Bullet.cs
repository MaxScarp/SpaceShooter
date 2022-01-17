using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    enum BulletType { PlayerBullet, EnemyBullet, LAST }

    abstract class Bullet
    {
        protected Texture texture;
        protected Sprite sprite;

        protected Vector2 velocity;
        protected float speed;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }

        public Bullet(string texturePath, int spriteWidth = 0, int spriteHeight = 0)
        {
            texture = new Texture(texturePath);

            int spriteW = spriteWidth != 0 ? spriteWidth : texture.Width;
            int spriteH = spriteHeight != 0 ? spriteHeight : texture.Height;

            sprite = new Sprite(spriteW, spriteH);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);
        }

        public virtual void Update()
        {
            Position += velocity * Game.DeltaTime;
        }

        public virtual void Draw()
        {
            sprite.DrawTexture(texture);
        }

        public void Shoot(Vector2 shootPos)
        {
            Position = shootPos;
        }
    }
}
