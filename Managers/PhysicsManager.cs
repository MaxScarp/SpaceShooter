using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class PhysicsManager
    {
        static List<RigidBody> items;

        static PhysicsManager()
        {
            items = new List<RigidBody>();
        }

        public static void AddItem(RigidBody rb)
        {
            items.Add(rb);
        }

        public static void RemoveItem(RigidBody rb)
        {
            items.Remove(rb);
        }

        public static void ClearAll()
        {
            items.Clear();
        }

        public static void Update()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].IsActive)
                {
                    items[i].Update();
                }
            }
        }

        public static void CheckCollisions()
        {
            for (int i = 0; i < items.Count - 1; i++)
            {
                if(items[i].IsActive && items[i].IsCollisionAffected)
                {
                    for (int j = i + 1; j < items.Count; j++)
                    {
                        if(items[j].IsActive && items[j].IsCollisionAffected)
                        {
                            bool firtsCheck = items[i].CollisionTypeMatches(items[j].Type);
                            bool secondCheck = items[j].CollisionTypeMatches(items[i].Type);

                            if((firtsCheck || secondCheck) && items[i].Collides(items[j]))
                            {
                                if(firtsCheck)
                                {
                                    items[i].GameObject.OnCollide(items[j].GameObject);
                                }
                                if(secondCheck)
                                {
                                    items[j].GameObject.OnCollide(items[i].GameObject);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
