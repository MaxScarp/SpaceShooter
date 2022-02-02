using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class ProgressBar : GameObject
    {
        private Texture barTexture;
        private Sprite barSprite;

        private Vector2 innerBarOffset;

        private float barWidth;

        public override Vector2 Position { get => base.Position; set { base.Position = value; barSprite.position = value + innerBarOffset; } }

        public ProgressBar(string frameTextureName, string barTextureName, Vector2 innerBarOffset) : base(frameTextureName)
        {
            barTexture = GfxManager.GetTexture(barTextureName);
            barSprite = new Sprite(barTexture.Width, barTexture.Height);

            this.innerBarOffset = innerBarOffset;
            Pivot = Vector2.Zero;
            barWidth = barSprite.Width;

            IsActive = true;
        }

        public void Scale(float scale)
        {
            scale = MathHelper.Clamp(scale, 0, 1);

            barSprite.scale.X = scale;
            barWidth = barSprite.Width * scale;

            float redMultiplier = 50.0f;
            float greenMultiplier = 2.0f;
            float blueMultiplier = 0.5f;
            barSprite.SetMultiplyTint((1.0f - scale) * redMultiplier, scale * greenMultiplier, scale * blueMultiplier, 1.0f);
        }

        public override void Draw()
        {
            if(IsActive)
            {
                base.Draw();
                barSprite.DrawTexture(barTexture, 0, 0, (int)barWidth, (int)barSprite.Height);
            }
        }
    }
}
