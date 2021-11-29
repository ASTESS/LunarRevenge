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
            worldTextures.Add("floor", GetTitle(new Rectangle(3264, 96, 99, 99)));
        }

        public Texture2D GetTitle(Rectangle box) //will split up sprite for easy use
                                                 //code idea from https://gamedev.stackexchange.com/questions/35358/create-a-texture2d-from-larger-image
        {
            Texture2D originalTexture = texture;

            Texture2D cropTexture = new Texture2D(graphicsDevice, box.Width, box.Height);
            Color[] data = new Color[box.Width * box.Height];
            originalTexture.GetData(0, box, data, 0, data.Length);
            cropTexture.SetData(data);

            /*Texture2D newTexture = new Texture2D(graphicsDevice, 96, 96); //making clean texture
            this.texture.GetData(0, box, color, 0, 9216);
            newTexture.SetData(color);
            newTexture.SaveAsPng(File.Create("test.png"), 96, 96);*/
            return cropTexture;
        }
    }
}
