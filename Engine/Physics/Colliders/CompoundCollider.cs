using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class CompoundCollider : Collider
    {
        private Collider boundingCollider;
        private List<Collider> colliders;

        public CompoundCollider(RigidBody owner, Collider boundingCollider) : base(owner)
        {
            this.boundingCollider = boundingCollider;
            colliders = new List<Collider>();

            if(boundingCollider is CircleCollider)
            {
                offset = Vector2.Zero;
            }

            if(boundingCollider is BoxCollider)
            {
                offset = new Vector2(((BoxCollider)boundingCollider).Width, ((BoxCollider)boundingCollider).Height);
            }
        }

        public void AddCollider(Collider collider)
        {
            colliders.Add(collider);
        }

        public bool InnerCollidersCollide(Collider other)
        {
            for (int i = 0; i < colliders.Count; i++)
            {
                if(other.Collides(colliders[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Contains(Vector2 point)
        {
            throw new NotImplementedException();
        }

        public override bool Collides(Collider other)
        {
            return other.Collides(boundingCollider);
        }

        public override bool Collides(CircleCollider other)
        {
            return other.Collides(boundingCollider) && InnerCollidersCollide(other);
        }

        public override bool Collides(BoxCollider other)
        {
            return other.Collides(boundingCollider) && InnerCollidersCollide(other);
        }

        public override bool Collides(CompoundCollider other)
        {
            if(boundingCollider.Collides(other.boundingCollider))
            {
                for (int i = 0; i < colliders.Count; i++)
                {
                    for (int j = 0; j < other.colliders.Count; j++)
                    {
                        if(colliders[i].Collides(other.colliders[j]))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
