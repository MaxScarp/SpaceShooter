using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    abstract class PowerUp : GameObject
    {
        private Player attachedPlayer;
        
        protected PowerUp(string textureName) : base(textureName)
        {
            RigidBody = new RigidBody(this);
            RigidBody.Collider = CollidersFactory.CreateCirlceFor(this);
            RigidBody.Type = RigidBodyType.PowerUp;
            RigidBody.AddCollisionType(RigidBodyType.Player);

            speed = -300.0f;
            RigidBody.Velocity.X = speed;
        }

        public override void Update()
        {
            if(IsActive)
            {
                if(Position.X + HalfWidth < 0)
                {
                    //Restore nel manager
                }
            }
        }

        public override void OnCollide(GameObject other)
        {
            OnAttach((Player)other);
        }

        private void OnAttach(Player p)
        {
            attachedPlayer = p;
            IsActive = false;
        }

        private void OnDetach()
        {
            attachedPlayer = null;
            //Restore to Manager
        }
    }
}
