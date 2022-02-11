using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class EnemyRed : Enemy
    {
        public EnemyRed() : base("enemyRed")
        {
            Type = EnemyType.Red;

            RigidBody.Collider = CollidersFactory.CreateBoxFor(this);

            speed = -375.0f;
            RigidBody.Velocity.X = speed;

            shootOffset = new Vector2(-Pivot.X, Pivot.Y * 0.5f);
            nextShoot = RandomGenerator.GetRandomFloat() + 0.3f;

            maxEnergy = 125;
        }
    }
}
