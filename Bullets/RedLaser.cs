using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class RedLaser : EnemyBullet
    {
        public RedLaser() : base("beams", 74, 46) { }

        public override void Draw()
        {
            sprite.DrawTexture(texture, 156, 227, (int)sprite.Width, (int)sprite.Height);
        }

        public override void OnCollide(GameObject other)
        {
            if (other is Player)
            {
                Console.WriteLine($"{GetType()} is colliding with {other.GetType()}");
            }
        }
    }
}
