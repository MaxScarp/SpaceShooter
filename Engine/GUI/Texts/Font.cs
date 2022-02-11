using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class Font
    {
        private int numCol;
        private int firstVal;

        public string TextureName { get; private set; }
        public Texture Texture { get; private set; }
        public int CharWidth { get; private set; }
        public int CharHeight { get; private set; }

        public Font(string textureName, string texturePath, int numColumns, int firstCharacterASCIIvalue, int charWidth, int charHeight)
        {
            TextureName = textureName;
            Texture = GfxManager.AddTexture(TextureName, texturePath);
            firstVal = firstCharacterASCIIvalue;
            CharWidth = charWidth;
            CharHeight = charHeight;
            numCol = numColumns;
        }

        public Vector2 GetOffset(char c)
        {
            int cVal = c;
            int delta = cVal - firstVal;
            int x = delta % numCol;
            int y = delta / numCol;

            return new Vector2(x * CharWidth, y * CharHeight);
        }
    }
}
