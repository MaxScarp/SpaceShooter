using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class BlueLaser : PlayerBullet
    {
        public BlueLaser() : base("blueLaser")
        {
            RigidBody.Collider = CollidersFactory.CreateBoxFor(this);

            speed = 1075.13f;

            damage = 25;
        }
    }
}
