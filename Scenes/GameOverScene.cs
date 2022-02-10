using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class GameOverScene : TitleScene
    {
        public GameOverScene() : base("Assets/gameOverBg.png", KeyCode.Y)
        {
        }

        public override void Input()
        {
            base.Input();

            if(IsPlaying && Game.Window.GetKey(KeyCode.N))
            {
                IsPlaying = false;
                NextScene = null;
            }
        }
    }
}
