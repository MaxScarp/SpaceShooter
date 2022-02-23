using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class FireGlobe : EnemyBullet
    {
        private float accumulator = 0;

        public FireGlobe() : base("fireGlobe") 
        {
            RigidBody.Collider = CollidersFactory.CreateCircleFor(this);

            damage = 50;
        }

        public override void Update()
        {
            if (IsActive)
            {
                base.Update();

                if (IsActive)
                {
                    sprite.Rotation -= Game.DeltaTime * 5.0f;

                    accumulator += Game.DeltaTime * 10.0f;
                    RigidBody.Velocity.Y = (float)Math.Sin(accumulator) * 850.0f;
                }
            }
        }
    }
}
