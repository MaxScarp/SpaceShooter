using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class JoypadController : Controller
    {
        public JoypadController(int controllerIndex) : base(controllerIndex)
        {

        }

        public override float GetHorizonatl()
        {
            float direction;

            return direction = Game.Window.JoystickAxisLeft(index).X;
        }

        public override float GetVertical()
        {
            float direction;

            return direction = Game.Window.JoystickAxisLeft(index).Y;
        }

        public override bool IsFirePressed()
        {
            return Game.Window.JoystickX(index);
        }
    }
}
