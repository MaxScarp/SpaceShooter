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
        public bool IsActive { get { return owner.IsActive; } }

        public RigidBody(GameObject owner)
        {
            this.owner = owner;

            IsCollisionAffected = true;

            PhysicsManager.AddItem(this);
        }

        public bool Collides(RigidBody rb)
        {
            return rb.Collider.Collides(Collider);
        }
    }
}
