using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class TextObject
    {
        private List<TextChar> sprites;
        private string text;
        private bool isActive;
        private Font font;
        readonly int hSpace;
        private Vector2 position;

        public bool IsActive { get { return isActive; } set { UpdateCharStatus(value); } }
        public string Text { get { return text; } set { SetText(value); } }

        public TextObject(Vector2 position, string textString = "", Font font = null, int horizontalSPace = 0)
        {
            this.position = position;
            hSpace = horizontalSPace;

            if(font == null)
            {
                font = FontManager.GetFont();
            }
            this.font = font;

            if(textString != "")
            {
                Text = textString;
            }
        }

        public void SetText(string newText)
        {
            if(newText != text)
            {
                text = newText;
                int numChars = text.Length;
                int charX = (int)position.X;
                int charY = (int)position.Y;

                for (int i = 0; i < numChars; i++)
                {
                    char c = text[i];

                    if(i > sprites.Count - 1)
                    {
                        TextChar tc = new TextChar(new Vector2(charX, charY), c, font);
                        sprites.Add(tc);
                    }
                    else if(c != sprites[i].Character)
                    {
                        sprites[i].Character = c;
                    }

                    charX += (int)sprites[i].HalfWidth * 2 + hSpace;
                }

                if(text.Length < sprites.Count)
                {
                    int count = sprites.Count - text.Length;
                    int startCut = text.Length;

                    for (int i = startCut; i < sprites.Count; i++)
                    {
                        sprites[i].Destroy();
                    }

                    sprites.RemoveRange(startCut, count);
                }
            }
        }

        public void UpdateCharStatus(bool activeStatus)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].IsActive = activeStatus;
            }
        }
    }
}
