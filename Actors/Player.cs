using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class Player : Actor
    {
        private ProgressBar energyBar;
        private TextObject playerName;
        private TextObject playerScore;

        private Controller controller;

        private int score;
        private int id;

        private bool shot;

        public override int Energy { get => base.Energy; set { base.Energy = value; energyBar.Scale((float)value / maxEnergy); } }
        public ProgressBar EnergyBar { get { return energyBar; } private set { energyBar = value; } }
        public TextObject PlayerName { get { return playerName; } }
        public TextObject PlayerScore { get { return playerScore; } }

        public Player(Controller controller, int id = 0) : base("player")
        {
            this.id = id;

            RigidBody.Type = RigidBodyType.Player;
            RigidBody.Collider = CollidersFactory.CreateBoxFor(this);
            RigidBody.AddCollisionType(RigidBodyType.Enemy);

            speed = 455.0f;
            tripleShootAngle = MathHelper.DegreesToRadians(15.0f);
            shot = false;
            bulletType = BulletType.PlayerBullet;
            shootOffset = new Vector2(sprite.pivot.X + 10.0f, sprite.pivot.Y - 10.0f);

            EnergyBar = new ProgressBar("frameBar", "bar", new Vector2(4.0f, 4.0f));

            maxEnergy = 100;
            Reset();

            this.controller = controller;

            IsActive = true;
        }

        public void Input()
        {
            if(IsAlive)
            {
                MovementInput();
                ShootInput();
            }
        }

        public void SetEnergyBarPosition(Vector2 energyBarPos)
        {
            EnergyBar.Position = energyBarPos;
        }

        public void SetPlayerNamePosition(Vector2 playerNamePos)
        {
            playerName = new TextObject(playerNamePos, $"Player {id + 1}", FontManager.GetFont(), 5);
            playerName.IsActive = true;
        }

        public void SetPlayerScorePos(Vector2 playerScorePos)
        {
            playerScore = new TextObject(playerScorePos, "0", FontManager.GetFont());
            playerScore.IsActive = true;
            UpdateScore();
        }

        private void UpdateScore()
        {
            playerScore.Text = score.ToString("00000");
        }

        private void ShootInput()
        {
            if (controller.IsFirePressed())
            {
                if (!shot)
                {
                    shot = true;
                    Shoot(id);
                }
            }
            else
            {
                shot = false;
            }
        }

        private void CheckBounds()
        {
            if(Position.X + HalfWidth >= Game.Window.Width)
            {
                sprite.position.X = Game.Window.Width - HalfWidth;
            }
            else if(Position.X - HalfWidth <= 0)
            {
                sprite.position.X = HalfWidth;
            }

            if(Position.Y - HalfHeight <= 0)
            {
                sprite.position.Y = HalfHeight;
            }
            else if(Position.Y + HalfHeight >= Game.Window.Height)
            {
                sprite.position.Y = Game.Window.Height - HalfHeight;
            }
        }

        private void MovementInput()
        {
            Vector2 direction = new Vector2(controller.GetHorizonatl(), controller.GetVertical());

            if(direction.Length > 1)
            {
                direction.Normalize();
            }

            CheckBounds();

            RigidBody.Velocity = direction * speed;
        }

        public void AddScore(int points)
        {
            score += points;
            UpdateScore();
        }

        public override void OnCollide(GameObject other)
        {
            SpawnManager.RestoreEnemy((Enemy)other);
            AddDamage(100);
        }

        protected override void OnDie()
        {
            IsActive = false;
            playerName.IsActive = false;
            playerScore.IsActive = false;
            EnergyBar.IsActive = false;
        }
    }
}
