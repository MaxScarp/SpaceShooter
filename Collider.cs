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
        private RigidBody owner;

        public Vector2 Position { get { return owner.Position; } }

        public Collider(RigidBody rb)
        {
            owner = rb;
        }

        public abstract bool Collides(Collider collider);
        public abstract bool Collides(CircleCollider collider);
    }
}
