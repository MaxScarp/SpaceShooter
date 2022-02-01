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
        protected Vector2 offset;
        protected RigidBody rigidBody;

        public Vector2 Position { get { return rigidBody.Position + offset; } }

        public Collider(RigidBody owner)
        {
            rigidBody = owner;
            offset = Vector2.Zero;
        }

        public abstract bool Contains(Vector2 point);
        public abstract bool Collides(Collider collider);
        public abstract bool Collides(CircleCollider collider);
        public abstract bool Collides(BoxCollider collider);

    }
}
