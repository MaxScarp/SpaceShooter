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

        private static List<JoypadController> joypads;
        private static KeyboardController keyboardController;

        public static Window Window { get { return window; } }
        public static float DeltaTime { get { return window.DeltaTime; } }
        public static Scene CurrentScene { get; private set; }
        public static List<JoypadController> Joypads { get { return joypads; } }

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

            //CONTROLLERS
            keyboardController = new KeyboardController(0);

            string[] joysticks = Window.Joysticks;
            joypads = new List<JoypadController>();

            for (int i = 0; i < joysticks.Length; i++)
            {
                if(joysticks[i] != null && joysticks[i] != "Unmapped Controller")
                {
                    joypads.Add(new JoypadController(i));
                }
            }
        }

        public static Controller GetController(int index)
        {
            Controller controller = keyboardController;

            if(index < joypads.Count)
            {
                controller = joypads[index];
            }

            return controller;
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
