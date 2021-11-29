﻿using Microsoft.Xna.Framework;
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
            worldTextures.Add("floor", GetTitle(new Rectangle(288, 192, 96,96)));
        }

        public Texture2D GetTitle(Rectangle box)
        {
            Texture2D originalTexture = texture;
            Rectangle sourceRectangle = new Rectangle(3266, 98, 95, 95); //of 96

            Texture2D cropTexture = new Texture2D(graphicsDevice, sourceRectangle.Width, sourceRectangle.Height);
            Color[] data = new Color[sourceRectangle.Width * sourceRectangle.Height];
            originalTexture.GetData(0, sourceRectangle, data, 0, data.Length);
            cropTexture.SetData(data);

            /*Texture2D newTexture = new Texture2D(graphicsDevice, 96, 96); //making clean texture
            this.texture.GetData(0, box, color, 0, 9216);
            newTexture.SetData(color);
            newTexture.SaveAsPng(File.Create("test.png"), 96, 96);*/
            return cropTexture;
        }
    }
}
