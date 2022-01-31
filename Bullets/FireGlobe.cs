using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class FireGlobe : EnemyBullet
    {
        public FireGlobe() : base("fireGlobe") { }

        public override void OnCollide(GameObject other)
        {
            if (other is Player)
            {
                Console.WriteLine($"{GetType()} is colliding with {other.GetType()}");
            }
        }
    }

}
