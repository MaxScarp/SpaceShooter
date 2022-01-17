using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class Actor
    {
        protected Texture texture;
        protected Sprite sprite;

        protected Vector2 velocity;
        protected float speed;

        protected Vector2 shootOffset;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }
        public Vector2 Pivot { get { return sprite.pivot; } set { sprite.pivot = value; } }

        public Actor(string texturePath)
        {
            texture = new Texture(texturePath);
            sprite = new Sprite(texture.Width, texture.Height);
            Pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);
        }

        public virtual void Update()
        {
            Position += velocity * Game.DeltaTime;
        }

        public virtual void Draw()
        {
            sprite.DrawTexture(texture);
        }

        protected virtual void Shoot()
        {

        }
    }
}
