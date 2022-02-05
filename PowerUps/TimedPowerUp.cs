using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    abstract class TimedPowerUp : PowerUp
    {
        private float duration;
        private float counter;

        protected TimedPowerUp(string textureName) : base(textureName)
        {
            duration = 5.0f;
        }

        protected override void OnAttach(Player p)
        {
            base.OnAttach(p);
            counter = duration;
        }

        public override void Update()
        {
            base.Update();

            if(attachedPlayer != null)
            {
                counter -= Game.DeltaTime;

                if(counter <= 0.0f)
                {
                    OnDetach();
                }
            }
        }
    }
}
