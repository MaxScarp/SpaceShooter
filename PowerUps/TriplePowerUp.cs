using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class TriplePowerUp : TimedPowerUp
    {
        public TriplePowerUp() : base("triple") { }

        protected override void OnAttach(Player p)
        { 
            base.OnAttach(p);
            attachedPlayer.ChangeWeapon(WeaponType.Triple);
        }

        protected override void OnDetach()
        {
            attachedPlayer.ChangeWeapon(WeaponType.Default);
            base.OnDetach();
        }
    }
}
