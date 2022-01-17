using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    static class Game
    {
        private static Window window;
        private static Background background;
        private static Player player;

        private static int playerNumBullets;
        private static int enemyNumBullets;

        public static Window Window { get { return window; } }
        public static float DeltaTime { get { return window.DeltaTime; } }

        public static void Init()
        {
            //CANVAS
            window = new Window(1280, 720, "SPACE SHOOTER");
            background = new Background();

            //PLAYER
            player = new Player();
            player.Position = new Vector2(100, window.Height * 0.5f);

            //MANAGERS
            playerNumBullets = 10;
            enemyNumBullets = 16;
            BulletManager.Init(playerNumBullets, enemyNumBullets);
            SpawnManager.Init();
        }

        public static void Play()
        {
            while(window.IsOpened)
            {
                //INPUT
                Quit();
                player.Input();

                //UPDATE
                background.Update();
                player.Update();
                BulletManager.Update();
                SpawnManager.Update();

                //DRAW
                background.Draw();
                player.Draw();
                BulletManager.Draw();
                SpawnManager.Draw();

                window.Update();
            }
        }

        private static void Quit()
        {
            if (window.GetKey(KeyCode.Esc))
            {
                window.Exit();
            }
        }
    }
}
