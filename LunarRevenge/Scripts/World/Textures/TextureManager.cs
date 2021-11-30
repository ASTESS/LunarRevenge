using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LunarRevenge.Scripts.World.Textures
{
    class TextureManager
    {
        public Dictionary<string,Texture2D> worldTextures = new Dictionary<string, Texture2D>();
        private Texture2D texture;
        private GraphicsDevice graphicsDevice;
        private Color[] color = new Color[9216];
        public TextureManager(Texture2D texture, GraphicsDevice graphics)
        {
            this.texture = texture;
            this.graphicsDevice = graphics;
            worldTextures.Add("floor", GetTitle(new Rectangle(1088, 32, 32, 32)));
            worldTextures.Add("waterTopMiddle", GetTitle(new Rectangle(1120, 64, 32, 32)));
            worldTextures.Add("waterTopLeft", GetTitle(new Rectangle(1088, 64, 32, 32)));
            worldTextures.Add("waterTopRight", GetTitle(new Rectangle(1152, 64, 32, 32)));
            worldTextures.Add("waterBottomMiddle", GetTitle(new Rectangle(1120, 96, 32, 32)));
            worldTextures.Add("waterBottomLeft", GetTitle(new Rectangle(1088, 96, 32, 32)));
            worldTextures.Add("waterBottomRight", GetTitle(new Rectangle(1152, 96, 32, 32)));
        }

        public Texture2D GetTitle(Rectangle box) //will split up sprite for easy use
                                                 //code idea from https://gamedev.stackexchange.com/questions/35358/create-a-texture2d-from-larger-image
        {
            Texture2D cropTexture = new Texture2D(graphicsDevice, box.Width, box.Height);
            Color[] data = new Color[box.Width * box.Height];
            texture.GetData(0, box, data, 0, data.Length);
            cropTexture.SetData(data);
            return cropTexture;
        }
    }
}
