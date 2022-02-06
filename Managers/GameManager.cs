using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class GameManager
    {
        private static Background bg;

        private static float timeToBoss;
        private static bool timeout;

        public static void Init(Background _bg)
        {
            bg = _bg;
            timeout = false;
            timeToBoss = 5.0f; //To change to 35.0s
        }

        public static void Update()
        {
            if (!timeout)
            {
                timeToBoss -= Game.DeltaTime;

                if (timeToBoss <= 0.0f)
                {
                    timeout = true;
                    InitiBossFight(bg);
                } 
            }
        }

        private static void InitiBossFight(Background bg)
        {
            bg.StopScrolling();
            SpawnManager.StopSpawning();
            PowerUpManager.StopSpawningEnergyPowerUp();

            SpawnManager.SpawnBoss();
        }
    }
}
