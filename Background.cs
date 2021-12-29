using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    class Background
    {
        private int spritesNum;
        private Texture texture;
        private Sprite[] sprites;
        private float offset;

        private float speed;

        public Background()
        {
            spritesNum = 2;
            texture = new Texture("Assets/spaceBg.png");
            sprites = new Sprite[spritesNum];

            for (int i = 0; i < spritesNum; i++)
            {
                sprites[i] = new Sprite(texture.Width, texture.Height);
                sprites[i].position = new Vector2(i * sprites[i].Width, 0f);
            }

            offset = 5f;
            speed = 250.0f;
        }

        public void Update()
        {
            for (int i = 0; i < spritesNum; i++)
            {
                sprites[i].position.X -= speed * Game.DeltaTime;
                if(sprites[i].position.X <= -sprites[i].Width)
                {
                    sprites[i].position = new Vector2(sprites[i].Width - offset, 0f);
                }
            }
        }
        public void Draw()
        {
            for (int i = 0; i < spritesNum; i++)
            {
                sprites[i].DrawTexture(texture);
            }
        }
    }
}
