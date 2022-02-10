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
        public Vector2 Offset;
        protected RigidBody rigidBody;

        public Vector2 Position { get { return rigidBody.Position + Offset; } }
        public RigidBody RigidBody { get { return rigidBody; } }

        public Collider(RigidBody owner)
        {
            rigidBody = owner;
            Offset = Vector2.Zero;
        }

        public abstract bool Contains(Vector2 point);
        public abstract bool Collides(Collider collider);
        public abstract bool Collides(CircleCollider collider);
        public abstract bool Collides(BoxCollider collider);
        public abstract bool Collides(CompoundCollider collider);

    }
}
