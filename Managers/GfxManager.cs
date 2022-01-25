using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class GfxManager
    {
        static private Dictionary<string, Texture> textures;

        static GfxManager()
        {
            textures = new Dictionary<string, Texture>();
        }

        public static Texture AddTexture(string name, string path)
        {
            Texture texture = new Texture(path);

            if(texture != null)
            {
                textures.Add(name, texture);
            }

            return texture;
        }

        public static Texture GetTexture(string name)
        {
            Texture t = null;

            if(textures.ContainsKey(name))
            {
                t = textures[name];
            }

            return t;
        }

        public static void ClearAll()
        {
            textures.Clear();
        }
    }
}
