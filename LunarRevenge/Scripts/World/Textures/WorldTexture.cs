using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.World.Textures
{
    class WorldTexture
    {
        public string name;
        Texture2D texture;

        public WorldTexture(string name, Texture2D texture)
        {
            this.name = name;
            this.texture = texture;
        }
    }
}
