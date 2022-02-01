using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class CollidersFactory
    {
        public static BoxCollider CreateBoxFor(GameObject obj, int width, int height)
        {
            float halfWidth = width * 0.5f;
            float halfHeight = height * 0.5f;

            return new BoxCollider(obj.RigidBody, halfWidth, halfHeight);
        }

        public static CircleCollider CreateCirlceFor(GameObject obj, bool innerCircle = true)
        {
            float radius;

            if(innerCircle)
            {
                if(obj.HalfWidth < obj.HalfHeight)
                {
                    radius = obj.HalfWidth;
                }
                else
                {
                    radius = obj.HalfHeight;
                }
            }
            else
            {
                radius = (float)Math.Sqrt(obj.HalfWidth * obj.HalfWidth + obj.HalfHeight * obj.HalfHeight);
            }

            return new CircleCollider(obj.RigidBody, radius);
        }
    }
}
