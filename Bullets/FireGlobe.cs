using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class FireGlobe : EnemyBullet
    {
        public FireGlobe() : base("fireGlobe")
        {
            RigidBody = new RigidBody(this);
            RigidBody.Collider = CollidersFactory.CreateCircleColliderFor(this);
        }

        public override void OnCollide(GameObject other)
        {
            //throw new NotImplementedException();
        }
    }
}
