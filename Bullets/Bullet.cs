using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    enum BulletType { PlayerBullet, EnemyBullet, LAST }

    abstract class Bullet : GameObject
    {
        public Bullet(string textureName, int spriteWidth = 0, int spriteHeight = 0) : base(textureName, spriteWidth, spriteHeight)
        {
            RigidBody = new RigidBody(this);
            RigidBody.Collider = ColliderFactory.CreateCirlceFor(this);
        }

        public void Shoot(Vector2 shootPos)
        {
            Position = shootPos;
        }

        public override void OnCollide(GameObject other)
        {
            BulletManager.RestoreBullet(this);
        }
    }
}
