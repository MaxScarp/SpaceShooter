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
        private Collider collider;

        public bool IsCollisionAffected;

        public Vector2 Position { get { return owner.Position; } }
        public Collider Collider { set { collider = value; } }
        public GameObject Owner { get { return owner; } }
        public bool IsActive { get { return owner.IsActive; } }

        public RigidBody(GameObject obj)
        {
            owner = obj;

            IsCollisionAffected = true;

            PhysicManager.AddItem(this);
        }

        public bool Collides(RigidBody other)
        {
            return collider.Collides(other.collider);
        }
    }
}
