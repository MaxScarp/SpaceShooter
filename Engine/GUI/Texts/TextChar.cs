﻿using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class TextChar : GameObject
    {
        private Font font;
        private char character;
        private Vector2 textureOffset;

        public char Character { get { return character; } set { character = value; ComputeOffset(); } }

        public TextChar(Vector2 spritePosition, char character, Font font) : base(font.TextureName, font.CharWidth, font.CharHeight)
        {
            Position = spritePosition;
            this.font = font;
            Character = character;
            Pivot = Vector2.Zero;
            IsActive = true;
        }

        private void ComputeOffset()
        {
            textureOffset = font.GetOffset(character);
        }

        public override void Draw()
        {
            if(IsActive)
            {
                sprite.DrawTexture(texture, (int)textureOffset.X, (int)textureOffset.Y, font.CharWidth, font.CharHeight);
            }
        }
    }
}
