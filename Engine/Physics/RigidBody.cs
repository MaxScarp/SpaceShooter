using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    enum RigidBodyType { Player = 1, PlayerBullet = 2, Enemy = 4, EnemyBullet = 8, PowerUp = 16 }

    class RigidBody
    {
        private GameObject gameObject;
        private Collider collider;

        protected uint collisionMask;

        public RigidBodyType Type;

        public Vector2 Velocity;

        public bool IsCollisionAffected;

        public bool IsActive { get { return gameObject.IsActive; } }
        public GameObject GameObject { get { return gameObject; } }
        public Collider Collider { set { collider = value; } }
        public Vector2 Position { get { return gameObject.Position; } set { gameObject.Position = value; } }

        public RigidBody(GameObject owner)
        {
            gameObject = owner;

            IsCollisionAffected = true;

            PhysicsManager.AddItem(this);
        }

        public void Update()
        {
            Position += Velocity * Game.DeltaTime; 
        }

        public bool Collides(RigidBody other)
        {
            return collider.Collides(other.collider);
        }

        public void AddCollisionType(RigidBodyType type)
        {
            collisionMask |= (uint)type;
        }

        public bool CollisionTypeMatches(RigidBodyType type)
        {
            return ((uint)type & collisionMask) != 0;
        }
    }
}
