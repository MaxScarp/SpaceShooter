using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class EnemyBullet : Bullet
    {
        public EnemyBullet() : base("Assets/beams.png", 74, 46)
        {
            sprite.FlipX = true;

            speed = -950.13f;
            velocity.X = speed;
        }

        public override void Update()
        {
            base.Update();
            if (Position.X + sprite.pivot.X < 0)
            {
                BulletManager.RestoreBullet(this);
            }
        }

        public override void Draw()
        {
            sprite.DrawTexture(texture, 156, 227, (int)sprite.Width, (int)sprite.Height);
        }
    }
}
