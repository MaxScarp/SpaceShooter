using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    enum WeaponType { Default, Triple, LAST }

    abstract class Actor : GameObject
    {
        protected WeaponType weaponType;
        
        protected BulletType bulletType;
        protected Vector2 shootOffset;
        protected float tripleShootAngle;

        protected int energy;
        protected int maxEnergy;

        public virtual int Energy { get { return energy; } set { energy = MathHelper.Clamp(value, 0, maxEnergy); } }
        public bool IsAlive { get { return Energy > 0; } }

        public Actor(string texturePath) : base(texturePath)
        {
            RigidBody = new RigidBody(this);
        }
        
        public void ChangeWeapon(WeaponType newWeapon)
        {
            weaponType = newWeapon;
        }

        public void NextWeapon()
        {
            if(weaponType == (WeaponType.LAST - 1))
            {
                weaponType = 0;
            }
            else
            {
                weaponType++;
            }
        }

        protected virtual void Shoot(int playerId = -1)
        {
            Bullet bullet;

            switch (weaponType)
            {
                case WeaponType.Default:
                    if(playerId != -1)
                    {
                        bullet = BulletManager.GetBullet(bulletType, playerId);
                    }
                    else
                    {
                        bullet = BulletManager.GetBullet(bulletType);
                    }

                    if(bullet != null)
                    {
                        bullet.Shoot(Position + shootOffset, new Vector2(bullet.Speed, 0.0f));
                    }
                    break;
                case WeaponType.Triple:
                    float x = (float)Math.Cos(tripleShootAngle);
                    float y = (float)Math.Sin(tripleShootAngle);
                    Vector2 bulletDir = new Vector2(x, y);

                    for (int i = 0; i < 3; i++)
                    {
                        if(playerId != -1)
                        {
                            bullet = BulletManager.GetBullet(bulletType, playerId);
                        }
                        else
                        {
                            bullet = BulletManager.GetBullet(bulletType);
                        }

                        if (bullet != null)
                        {
                            bullet.Shoot(Position + shootOffset, bulletDir.Normalized() * bullet.Speed);
                            bulletDir.Y -= y;
                        }
                    }
                    break;
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
