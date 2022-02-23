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
        private Player player1;
        private Player player2;

        private int playerNumBullets;
        private int enemyNumBullets;

        public Player Player1 { get { return player1; } }
        public Player Player2 { get { return player2; } }


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
            player1 = null;

            ClearScene();
            
            return base.OnExit();
        }

        public override void Input()
        {
            base.Input();

            player1.Input();

            if(player2 != null)
            {
                player2.Input();
            }
        }
        public override void Update()
        {
            if(player2 != null)
            {
                if (!player1.IsAlive && !player2.IsAlive)
                {
                    IsPlaying = false;
                }
            }
            else
            {
                if(!player1.IsAlive)
                {
                    IsPlaying = false;
                    return;
                }
            }

            if(!player1.IsAlive)
            {
                player2.PlayerName.IsActive = false;
                player2.PlayerScore.IsActive = false;

                player2.SetEnergyBarPosition(player1.EnergyBar.Position);
                Player2.SetPlayerNamePosition(player2.EnergyBar.Position + new Vector2(0.0f, -20.0f));
                player2.SetPlayerScorePos(player2.EnergyBar.Position + new Vector2(0.0f, 20.0f));
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
            GfxManager.AddTexture("greenGlobe", "Assets/greenGlobe.png");

            GfxManager.AddTexture("frameBar", "Assets/loadingBar_frame.png");
            GfxManager.AddTexture("bar", "Assets/loadingBar_bar.png");

            GfxManager.AddTexture("battery", "Assets/powerUp_battery.png");
            GfxManager.AddTexture("triple", "Assets/powerUp_triple.png");
        }

        private void InitScene()
        {
            LoadAssets();

            FontManager.Init();
            FontManager.AddFont("stdFont", "Assets/textSheet.png", 15, 32, 20, 20);
            FontManager.AddFont("comics", "Assets/comics.png", 10, 32, 61, 65);

            background = new Background();

            //PLAYER 1
            player1 = new Player(Game.GetController(0));
            player1.Position = new Vector2(100, Game.Window.Height * 0.5f - 50.0f);
            player1.SetEnergyBarPosition(new Vector2(60.0f, 50.0f));
            player1.SetPlayerNamePosition(player1.EnergyBar.Position + new Vector2(0.0f, -20.0f));
            player1.SetPlayerScorePos(player1.EnergyBar.Position + new Vector2(0.0f, 20.0f));

            //PLAYER2
            if (Game.Joypads.Count >= 1 && Game.Joypads[0] != null)
            {
                player2 = new Player(Game.GetController(1), 1);
                player2.Position = new Vector2(100, Game.Window.Height * 0.5f + 50.0f);
                player2.EnergyBar.Position = new Vector2(60.0f, 50.0f);
                player2.SetEnergyBarPosition(player1.EnergyBar.Position + new Vector2(player1.EnergyBar.HalfWidth * 2 + 15.0f, 0.0f));
                player2.SetPlayerNamePosition(player2.EnergyBar.Position + new Vector2(0.0f, -20.0f));
                player2.SetPlayerScorePos(player2.EnergyBar.Position + new Vector2(0.0f, 20.0f)); 
            }

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
