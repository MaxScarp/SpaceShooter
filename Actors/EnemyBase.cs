using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class EnemyBase : Enemy
    {
        public EnemyBase() : base("enemy")
        {
            Type = EnemyType.Base;

            RigidBody.Collider = CollidersFactory.CreateBoxFor(this);

            speed = -475.0f;
            RigidBody.Velocity.X = speed;

            shootOffset = new Vector2(-Pivot.X, Pivot.Y * 0.5f);
            nextShoot = RandomGenerator.GetRandomFloat() + 0.3f;

            maxEnergy = 50;

            Points = 20;
        }
    }
}
