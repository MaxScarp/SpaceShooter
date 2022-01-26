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
        private GameObject gameObject;
        private Collider collider;

        public bool IsCollisionAffected;
        public bool IsActive;

        public GameObject GameObject { get { return gameObject; } }
        public Collider Collider { set { collider = value; } }

        public Vector2 Position { get { return gameObject.Position; } }

        public RigidBody(GameObject owner)
        {
            gameObject = owner;

            IsCollisionAffected = true;
            IsActive = false;

            PhysicsManager.AddItem(this);
        }

        public bool Collides(RigidBody other)
        {
            return collider.Collides(other.collider);
        }
    }
}
