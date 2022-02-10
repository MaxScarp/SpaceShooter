using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class BoxCollider : Collider
    {
        private float halfWidth;
        private float halfHeight;

        public float Width { get { return halfWidth * 2.0f; } }
        public float Height { get { return halfHeight * 2.0f; } }

        public BoxCollider(RigidBody owner, int w, int h) : base(owner)
        {
            halfWidth = w * 0.5f;
            halfHeight = h * 0.5f;

            DebugManager.AddItem(this);
        }

        public override bool Collides(BoxCollider other)
        {
            float deltaX = other.Position.X - Position.X;
            float deltaY = other.Position.Y - Position.Y;

            return
                (Math.Abs(deltaX) <= other.halfWidth + halfWidth) &&
                (Math.Abs(deltaY) <= other.halfHeight + halfHeight);
        }

        public override bool Collides(Collider other)
        {
            return other.Collides(this);
        }

        public override bool Collides(CircleCollider circle)
        {
            float deltaX = circle.Position.X - Math.Max(Position.X - halfWidth, Math.Min(circle.Position.X, Position.X + halfWidth));
            float deltaY = circle.Position.Y - Math.Max(Position.Y - halfHeight, Math.Min(circle.Position.Y, Position.Y + halfHeight));

            return (deltaX * deltaX + deltaY * deltaY) <= (circle.Radius * circle.Radius);
        }

        public override bool Contains(Vector2 point)
        {
            return
                point.X >= Position.X - halfWidth &&
                point.X <= Position.X + halfWidth &&
                point.Y >= Position.Y - halfHeight &&
                point.Y <= Position.Y + halfHeight;
        }

        public override bool Collides(CompoundCollider other)
        {
            return other.Collides(this);
        }
    }
}
