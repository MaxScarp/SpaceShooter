using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class RigidBody
    {
        private GameObject owner;

        public Collider Collider;
        public bool IsCollisionAffected;

        public Vector2 Position { get { return owner.Position; } }
        public GameObject Owner { get { return owner; } }

        public RigidBody(GameObject obj)
        {
            owner = obj;

            IsCollisionAffected = true;

            PhysicsManager.AddItem(this);
        }

        public bool Collides(RigidBody other)
        {
            return other.Collider.Collides(Collider);
        }
    }
}
