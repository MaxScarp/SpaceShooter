﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class CollidersFactory
    {
        public static CircleCollider CreateCircleFor(GameObject obj, bool isInnerCircle = true)
        {
            float radius;

            if(isInnerCircle)
            {
                if(obj.HalfWidth <= obj.HalfHeight)
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
