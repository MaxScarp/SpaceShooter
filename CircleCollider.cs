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

        public CircleCollider(RigidBody rb, float radius) : base(rb)
        {
            this.radius = radius;
        }

        public override bool Collides(Collider other)
        {
            return other.Collides(this);
        }

        public override bool Collides(CircleCollider other)
        {
            Vector2 dist = other.Position - Position;
            return dist.LengthSquared <= Math.Pow(other.radius + radius , 2);
        }
    }
}
