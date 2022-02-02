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

        protected float speed;

        public RigidBody RigidBody;

        public bool IsActive;

        public virtual Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }
        public Vector2 Pivot { get { return sprite.pivot; } set { sprite.pivot = value; } }
        public float HalfWidth { get; private set; }
        public float HalfHeight { get; private set; }

        public GameObject(string textureName, int spriteWidth = 0, int spriteHeight = 0)
        {
            texture = GfxManager.GetTexture(textureName);

            int spriteW = spriteWidth != 0 ? spriteWidth : texture.Width;
            int spriteH = spriteHeight != 0 ? spriteHeight : texture.Height;

            sprite = new Sprite(spriteW, spriteH);
            Pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);

            HalfWidth = sprite.Width * 0.5f;
            HalfHeight = sprite.Height * 0.5f;

            IsActive = false;

            UpdateManager.AddItem(this);
            DrawManager.AddItem(this);
        }

        public virtual void Update() { }

        public virtual void Draw()
        {
            if (IsActive)
            {
                sprite.DrawTexture(texture); 
            }
        }

        public virtual void OnCollide(GameObject other) { }
    }
}
