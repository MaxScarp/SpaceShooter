using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    abstract class Scene
    {
        public Scene NextScene;

        public bool IsPlaying { get; protected set; }

        public Scene()
        {

        }

        public virtual void Start()
        {
            IsPlaying = true;
        }

        public virtual Scene OnExit()
        {
            IsPlaying = false;
            return NextScene;
        }

        protected virtual void LoadAssets()
        {

        }

        public virtual void Input()
        {
            Quit();
        }
        public abstract void Update();
        public abstract void Draw();

        private void Quit()
        {
            if (Game.Window.GetKey(KeyCode.Esc))
            {
                Game.Window.Exit();
            }
        }
    }
}
