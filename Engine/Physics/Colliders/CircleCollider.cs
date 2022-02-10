using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class CircleCollider : Collider
    {
        private float radius;

        public float Radius { get { return radius; } }

        public CircleCollider(RigidBody owner, float radius) : base(owner)
        {
            this.radius = radius;

            DebugManager.AddItem(this);
        }

        public override bool Collides(BoxCollider other)
        {
            return other.Collides(this);
        }

        public override bool Collides(Collider other)
        {
            return other.Collides(this);
        }

        public override bool Collides(CircleCollider other)
        {
            Vector2 dist = other.Position - Position;
            return dist.LengthSquared <= Math.Pow(other.radius + radius, 2);
        }

        public override bool Contains(Vector2 point)
        {
            Vector2 dist = point - Position;
            return dist.LengthSquared <= Math.Pow(radius, 2);
        }

        public override bool Collides(CompoundCollider other)
        {
            return other.Collides(this);
        }
    }
}
