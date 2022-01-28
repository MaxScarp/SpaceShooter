using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class RedLaser : EnemyBullet
    {
        public RedLaser() : base("beams", 74, 46)
        {
            damage = 25;
        }

        public override void Draw()
        {
            if (IsActive)
            {
                sprite.DrawTexture(texture, 156, 227, (int)sprite.Width, (int)sprite.Height);
            }
        }
    }
}
