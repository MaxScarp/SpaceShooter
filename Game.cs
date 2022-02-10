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
            window.SetVSync(false);

            LoadAssets();

            background = new Background();

            //PLAYER
            player = new Player();
            player.Position = new Vector2(100, window.Height * 0.5f);

            //MANAGERS
            playerNumBullets = 20;
            enemyNumBullets = 16;
            GameManager.Init(background);
            BulletManager.Init(playerNumBullets, enemyNumBullets);
            SpawnManager.Init();
            PowerUpManager.Init();
        }

        public static void Play()
        {
            while(window.IsOpened)
            {
                window.SetTitle($"FPS: {1.0f / DeltaTime}");

                //INPUT
                Quit();

                if (!player.IsAlive)
                    return;
                
                player.Input();

                //UPDATE
                GameManager.Update();

                background.Update();

                PhysicsManager.Update();
                SpawnManager.Update();
                UpdateManager.Update();
                PowerUpManager.Update();
                
                //COLLISIONS
                PhysicsManager.CheckCollisions();

                //DRAW
                background.Draw();

                DrawManager.Draw();
                DebugManager.Draw();

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

        private static void LoadAssets()
        {
            GfxManager.AddTexture("player", "Assets/player_ship.png");
            GfxManager.AddTexture("enemy", "Assets/enemy_ship.png");
            GfxManager.AddTexture("enemyRed", "Assets/redEnemy_ship.png");
            GfxManager.AddTexture("boss", "Assets/big_ship.png");

            GfxManager.AddTexture("blueLaser", "Assets/blueLaser.png");
            GfxManager.AddTexture("beams", "Assets/beams.png");
            GfxManager.AddTexture("fireGlobe", "Assets/fireGlobe.png");

            GfxManager.AddTexture("frameBar", "Assets/loadingBar_frame.png");
            GfxManager.AddTexture("bar", "Assets/loadingBar_bar.png");

            GfxManager.AddTexture("battery", "Assets/powerUp_battery.png");
            GfxManager.AddTexture("triple", "Assets/powerUp_triple.png");
        }
    }
}
