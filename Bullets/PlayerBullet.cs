using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    class PlayerBullet : Bullet
    {
        public PlayerBullet() : base("blueLaser")
        {
            RigidBody = new RigidBody(this);
            RigidBody.Collider = CollidersFactory.CreateCircleColliderFor(this);

            speed = 1075.13f;
            velocity.X = speed;
        }

        public override void OnCollide(GameObject other)
        {
            //throw new NotImplementedException();
        }

        public override void Update()
        {
            base.Update();
            if (Position.X - sprite.pivot.X > Game.Window.Width)
            {
                BulletManager.RestoreBullet(this);
            }
        }
    }
}
