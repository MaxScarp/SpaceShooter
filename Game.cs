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

        public static Window Window { get { return window; } }
        public static float DeltaTime { get { return window.DeltaTime; } }
        public static Scene CurrentScene { get; private set; }

        public static void Init()
        {
            //CANVAS
            window = new Window(1280, 720, "SPACE SHOOTER");
            window.SetVSync(false);

            //SCENES
            TitleScene titleScene = new TitleScene("Assets/aivBG.png");
            PlayScene playScene = new PlayScene();
            GameOverScene gameOverScene = new GameOverScene();

            titleScene.NextScene = playScene;
            playScene.NextScene = gameOverScene;
            gameOverScene.NextScene = titleScene;

            CurrentScene = titleScene;
        }

        public static void Play()
        {
            CurrentScene.Start();

            while(window.IsOpened)
            {
                window.SetTitle($"FPS: {1.0f / DeltaTime}");

                if(!CurrentScene.IsPlaying)
                {
                    Scene nextScene = CurrentScene.OnExit();

                    if(nextScene != null)
                    {
                        CurrentScene = nextScene;
                        CurrentScene.Start();
                    }
                    else
                    {
                        return;
                    }
                }

                //INPUT
                CurrentScene.Input();

                //UPDATE
                CurrentScene.Update();

                //DRAW
                CurrentScene.Draw();

                window.Update();
            }
        }
    }
}
