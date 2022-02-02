using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    abstract class Actor : GameObject
    {
        protected BulletType bulletType;
        protected Vector2 shootOffset;

        protected int energy;
        protected int maxEnergy;

        public virtual int Energy { get { return energy; } set { energy = MathHelper.Clamp(value, 0, maxEnergy); } }
        public bool IsAlive { get { return Energy > 0; } }

        public Actor(string texturePath) : base(texturePath)
        {
            RigidBody = new RigidBody(this);

            maxEnergy = 100;
        }

        protected virtual void Shoot()
        {
            Bullet bullet = BulletManager.GetBullet(bulletType);
            if (bullet != null)
            {
                bullet.Shoot(Position + shootOffset);
            }
        }

        public void AddDamage(int dmg)
        {
            Energy -= dmg;

            if(!IsAlive)
            {
                OnDie();
            }
        }

        protected virtual void OnDie() { }
        
        public void Reset()
        {
            Energy = maxEnergy;
        }
    }
}
