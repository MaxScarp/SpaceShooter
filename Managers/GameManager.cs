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
        private static bool stopped;

        public static void Init(Background _bg)
        {
            bg = _bg;
            timeout = false;
            timeToBoss = 35.0f;
            stopped = false;

            bg.StartScrolling();
            SpawnManager.StartSpawning();
        }

        public static void Update()
        {
            if (!timeout && !stopped)
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

            SpawnManager.SpawnBoss();
        }

        public static void Stop()
        {
            stopped = true;
            timeout = false;
        }
    }
}
