using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class GreenGlobe : PlayerBullet
    {
        public GreenGlobe() : base("greenGlobe")
        {
            RigidBody.Collider = CollidersFactory.CreateCircleFor(this);

            speed = 850.0f;

            damage = 50;
        }
    }
}
