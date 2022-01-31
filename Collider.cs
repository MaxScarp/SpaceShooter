using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    abstract class Collider
    {
        private RigidBody rigidBody;

        public Collider(RigidBody rb)
        {
            rigidBody = rb;
        }

        public Vector2 Position { get { return rigidBody.Position; } }

        public abstract bool Collides(Collider collider);
        public abstract bool Collides(CircleCollider collider);
    }
}
