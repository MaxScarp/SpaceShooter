using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class PlayScene : Scene
    {
        private Background background;
        private Player player;

        private int playerNumBullets;
        private int enemyNumBullets;

        public Player Player { get { return player; } }

        public PlayScene() : base()
        {
            playerNumBullets = 20;
            enemyNumBullets = 16;
        }

        public override void Start()
        {
            InitScene();

            base.Start();
        }

        public override Scene OnExit()
        {
            player = null;

            ClearScene();

            return base.OnExit();
        }

        public override void Input()
        {
            base.Input();

            player.Input();
        }
        public override void Update()
        {
            if (!player.IsAlive)
            {
                IsPlaying = false;
            }

            GameManager.Update();

            background.Update();

            PhysicsManager.Update();
            SpawnManager.Update();
            UpdateManager.Update();
            PowerUpManager.Update();

            //COLLISIONS
            PhysicsManager.CheckCollisions();
        }
        public override void Draw()
        {
            background.Draw();

            DrawManager.Draw();
            //DebugManager.Draw();
        }

        protected override void LoadAssets()
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

        private void InitScene()
        {
            LoadAssets();

            FontManager.Init();
            Font stdFont = FontManager.AddFont("stdFont", "Assets/textSheet.png", 15, 32, 20, 20);
            Font comic = FontManager.AddFont("comics", "Assets/comics.png", 10, 32, 61, 65);

            background = new Background();

            //PLAYER
            player = new Player();
            player.Position = new Vector2(100, Game.Window.Height * 0.5f);

            BulletManager.Init(playerNumBullets, enemyNumBullets);
            SpawnManager.Init();
            PowerUpManager.Init();
            GameManager.Init(background);
        }

        private void ClearScene()
        {
            BulletManager.ClearAll();
            DebugManager.ClearAll();
            DrawManager.ClearAll();
            GfxManager.ClearAll();
            PhysicsManager.ClearAll();
            PowerUpManager.ClearAll();
            SpawnManager.ClearAll();
            UpdateManager.ClearAll();
            FontManager.ClearAll();
            GameManager.Stop();
        }
    }
}
