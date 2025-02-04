﻿using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class Background
    {
        private Texture texture;
        private Sprite head;
        private Sprite tail;

        private Vector2 velocity;
        private float speed;

        private bool isStopped;

        public Background()
        {
            texture = new Texture("Assets/spaceBg.png");
            head = new Sprite(texture.Width, texture.Height);
            tail = new Sprite(texture.Width, texture.Height);

            speed = -275.0f;
            velocity.X = speed;

            isStopped = false;
        }

        public void Update()
        {
            if (!isStopped)
            {
                head.position.X += velocity.X * Game.DeltaTime;

                if (head.position.X <= -head.Width)
                {
                    head.position.X += head.Width;
                }

                tail.position.X = head.position.X + head.Width; 
            }
        }

        public void Draw()
        {
            head.DrawTexture(texture);
            tail.DrawTexture(texture);
        }

        public void StopScrolling()
        {
            isStopped = true;
        }

        public void StartScrolling()
        {
            isStopped = false;
        }
    }
}
