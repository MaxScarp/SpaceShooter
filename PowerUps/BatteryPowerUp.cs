using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class BatteryPowerUp : PowerUp
    {
        private int hpRecharge;

        public BatteryPowerUp() : base("battery")
        {
            hpRecharge = 0;
        }

        protected override void OnAttach(Player p)
        {
            base.OnAttach(p);

            if(hpRecharge != 0)
            {
                attachedPlayer.Energy += hpRecharge;
            }
            else
            {
                attachedPlayer.Reset();
            }
            OnDetach();
        }
    }
}
