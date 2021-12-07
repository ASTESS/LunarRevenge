using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.World.Textures
{
    class WorldTexture
    {
        public string name;
        public Texture2D texture;
        public Rectangle collisionBox;

        public WorldTexture(Texture2D texture, Rectangle rectangle)
        {
            //this.name = name;
            this.texture = texture;
            this.collisionBox = rectangle;
        }
    }
}
