using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class PowerUpManager
    {
        private static List<PowerUp> items;

        private static float nextSpawn;

        public static void Init()
        {
            items = new List<PowerUp>();

            nextSpawn = RandomGenerator.GetRandomInt(8, 20);

            items.Add(new BatteryPowerUp());
            items.Add(new TriplePowerUp());
        }

        public static void Update()
        {
            nextSpawn -= Game.DeltaTime;

            if(nextSpawn <= 0)
            {
                SpawnPowerUp();
                nextSpawn = RandomGenerator.GetRandomFloat() * 8 + 2;
            }
        }

        private static void SpawnPowerUp()
        {
            if(items.Count > 0)
            {
                int randomIndex = RandomGenerator.GetRandomInt(0, items.Count);

                PowerUp powerUp = items[randomIndex];
                items.RemoveAt(randomIndex);

                float randomPositionY = RandomGenerator.GetRandomInt((int)powerUp.HalfHeight, (int)(Game.Window.Height - powerUp.HalfHeight));
                powerUp.Position = new Vector2(Game.Window.Width + powerUp.HalfWidth, randomPositionY);

                powerUp.IsActive = true;
            }
        }

        public static void RestorePowerUp(PowerUp p)
        {
            p.IsActive = false;
            items.Add(p);
        }

        public static void ClearAll()
        {
            items.Clear();
        }
    }
}
