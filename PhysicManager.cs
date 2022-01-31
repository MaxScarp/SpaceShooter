using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class PhysicManager
    {
        private static List<RigidBody> items;

        static PhysicManager()
        {
            items = new List<RigidBody>();
        }

        public static void AddItem(RigidBody item)
        {
            items.Add(item);
        }

        public static void RemoveItem(RigidBody item)
        {
            items.Remove(item);
        }

        public static void ClearAll()
        {
            items.Clear();
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
                            if(items[i].Collides(items[j]))
                            {
                                items[i].Owner.OnCollide(items[j].Owner);
                                items[j].Owner.OnCollide(items[i].Owner);
                            }
                        }
                    }
                }
            }
        }
    }
}
