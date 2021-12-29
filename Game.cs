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

        private static int numBullets;

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
            numBullets = 10;
            BulletManager.Init(numBullets);
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

                //DRAW
                background.Draw();

                player.Draw();

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
