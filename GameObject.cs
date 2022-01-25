using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class GameObject : I_Updatable, I_Drawable
    {
        protected Texture texture;
        protected Sprite sprite;

        protected Vector2 velocity;
        protected float speed;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }
        public Vector2 Pivot { get { return sprite.pivot; } set { sprite.pivot = value; } }

        public GameObject(string textureName, int spriteWidth = 0, int spriteHeight = 0)
        {
            texture = GfxManager.GetTexture(textureName);

            int spriteW = spriteWidth != 0 ? spriteWidth : texture.Width;
            int spriteH = spriteHeight != 0 ? spriteHeight : texture.Height;

            sprite = new Sprite(spriteW, spriteH);
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
    }
}
