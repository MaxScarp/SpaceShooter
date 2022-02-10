using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class TitleScene : Scene
    {
        private Texture texture;
        private Sprite sprite;

        private string texturePath;
        private KeyCode exitKey;

        public TitleScene(string texturePath, KeyCode exitKey = KeyCode.Return) : base()
        {
            this.texturePath = texturePath;
            this.exitKey = exitKey;
        }

        public override void Start()
        {
            texture = new Texture(texturePath);
            sprite = new Sprite(Game.Window.Width, Game.Window.Height);

            base.Start();
        }

        public override Scene OnExit()
        {
            texture = null;
            sprite = null;

            return base.OnExit();
        }

        public override void Input()
        {
            base.Input();

            if(Game.Window.GetKey(exitKey))
            {
                IsPlaying = false;
            }
        }
        public override void Update() { }
        public override void Draw()
        {
            sprite.DrawTexture(texture);
        }
    }
}
