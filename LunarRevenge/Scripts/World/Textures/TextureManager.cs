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

            // Texture Explaination:
            // new Rectangle(x, y, z, z)
            // x = X Coordinate of LeftTop of the texture
            // y = Y Coordinate of LeffTop of the texture
            // z = The texture size (example: 32x32)

            // Floor Textures
            worldTextures.Add("floor", GetTitle(new Rectangle(1088, 32, 32, 32)));
            worldTextures.Add("floorVentBlack", GetTitle(new Rectangle(1024, 32, 32, 32)));
            worldTextures.Add("floorVentGreen", GetTitle(new Rectangle(1152, 32, 32, 32)));
            worldTextures.Add("floorCenter", GetTitle(new Rectangle(1024, 64, 32, 32)));
            worldTextures.Add("floorQuadTile", GetTitle(new Rectangle(1056, 32, 32, 32)));

            // Acid/Water Textures
            worldTextures.Add("waterTopMiddle", GetTitle(new Rectangle(1120, 64, 32, 32)));
            worldTextures.Add("waterTopLeft", GetTitle(new Rectangle(1088, 64, 32, 32)));
            worldTextures.Add("waterTopRight", GetTitle(new Rectangle(1152, 64, 32, 32)));
            worldTextures.Add("waterBottomMiddle", GetTitle(new Rectangle(1120, 96, 32, 32)));
            worldTextures.Add("waterBottomLeft", GetTitle(new Rectangle(1088, 96, 32, 32)));
            worldTextures.Add("waterBottomRight", GetTitle(new Rectangle(1152, 96, 32, 32)));

            // Wall Textures
            worldTextures.Add("wallTopMiddle", GetTitle(new Rectangle(160, 0, 32, 32)));
            worldTextures.Add("wallTopRight", GetTitle(new Rectangle(256, 0, 32, 32)));
            worldTextures.Add("wallRightSide", GetTitle(new Rectangle(288, 64, 32, 32)));

            // Prop Textures

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
