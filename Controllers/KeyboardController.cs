using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class KeyboardController : Controller
    {
        public KeyboardController(int controllerIndex) : base(controllerIndex)
        {

        }

        public override float GetHorizonatl()
        {
            float direction = 0.0f;

            if(Game.Window.GetKey(KeyCode.D))
            {
                direction = 1.0f;
            }
            else if(Game.Window.GetKey(KeyCode.D))
            {
                direction = -1.0f;
            }

            return direction;
        }

        public override float GetVertical()
        {
            float direction = 0.0f;

            if (Game.Window.GetKey(KeyCode.S))
            {
                direction = 1.0f;
            }
            else if (Game.Window.GetKey(KeyCode.W))
            {
                direction = -1.0f;
            }

            return direction;
        }

        public override bool IsFirePressed()
        {
            return Game.Window.GetKey(KeyCode.Space);
        }
    }
}
