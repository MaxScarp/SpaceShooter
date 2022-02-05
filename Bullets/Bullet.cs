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
        protected int damage;

        public Bullet(string textureName, int spriteWidth = 0, int spriteHeight = 0) : base(textureName, spriteWidth, spriteHeight)
        {
            RigidBody = new RigidBody(this);
        }

        public void Shoot(Vector2 shootPos, Vector2 shootVel)
        {
            Position = shootPos;
            RigidBody.Velocity = shootVel;
        }
    }
}
