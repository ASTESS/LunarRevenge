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
        public Dictionary<string, Texture2D> worldTextures = new Dictionary<string, Texture2D>();
        private Texture2D texture;
        private Texture2D props;
        private GraphicsDevice graphicsDevice;
        private Color[] color = new Color[9216];
        public TextureManager(Texture2D texture, Texture2D props, GraphicsDevice graphics)
        {
            this.texture = texture;
            this.graphicsDevice = graphics;
            this.props = props;

            // Texture Explaination:
            // new Rectangle(x, y, z, z)
            // x = X Coordinate of LeftTop of the texture
            // y = Y Coordinate of LeffTop of the texture
            // z = The texture size (example: 32x32)

            // Floor Textures
            worldTextures.Add("floor", GetTile(new Rectangle(1088, 32, 32, 32)));
            worldTextures.Add("floorVentBlack", GetTile(new Rectangle(1024, 32, 32, 32)));
            worldTextures.Add("floorVentGreen", GetTile(new Rectangle(1152, 32, 32, 32)));
            worldTextures.Add("floorCenter", GetTile(new Rectangle(1024, 64, 32, 32)));
            worldTextures.Add("floorQuadTile", GetTile(new Rectangle(1056, 32, 32, 32)));

            // Acid/Water Textures
            worldTextures.Add("waterTopMiddle", GetTile(new Rectangle(1120, 64, 32, 32)));
            worldTextures.Add("waterTopLeft", GetTile(new Rectangle(1088, 64, 32, 32)));
            worldTextures.Add("waterTopRight", GetTile(new Rectangle(1152, 64, 32, 32)));
            worldTextures.Add("waterBottomMiddle", GetTile(new Rectangle(1120, 96, 32, 32)));
            worldTextures.Add("waterBottomLeft", GetTile(new Rectangle(1088, 96, 32, 32)));
            worldTextures.Add("waterBottomRight", GetTile(new Rectangle(1152, 96, 32, 32)));

            // Wall Textures
            worldTextures.Add("wallTopMiddle", GetTile(new Rectangle(160, 0, 32, 32)));
            worldTextures.Add("wallTopMiddleEndLeft", GetTile(new Rectangle(160, 0, 32, 32)));
            worldTextures.Add("wallTopMiddleEndRight", GetTile(new Rectangle(160, 0, 32, 32)));
            worldTextures.Add("wallBottomMiddle", GetTile(new Rectangle(160, 320, 32, 32)));
            worldTextures.Add("wallBottomMiddleEndLeft", GetTile(new Rectangle(160, 320, 32, 32)));
            worldTextures.Add("wallBottomMiddleEndRight", GetTile(new Rectangle(160, 320, 32, 32)));
            worldTextures.Add("wallTopRight", GetTile(new Rectangle(256, 0, 32, 32)));
            worldTextures.Add("wallTopLeft", GetTile(new Rectangle(64, 0, 32, 32)));
            worldTextures.Add("wallBottomRight", GetTile(new Rectangle(256, 320, 32, 32)));
            worldTextures.Add("wallBottomLeft", GetTile(new Rectangle(64, 320, 32, 32)));
            worldTextures.Add("wallRightSide", GetTile(new Rectangle(288, 64, 32, 32)));
            worldTextures.Add("wallLeftSide", GetTile(new Rectangle(32, 64, 32, 32)));
            worldTextures.Add("wallLeftSideEndBottom", GetTile(new Rectangle(32, 96, 32, 32)));
            worldTextures.Add("wallLeftSideEndTop", GetTile(new Rectangle(32, 128, 32, 32)));
            worldTextures.Add("wallCornerLeftTop", GetTile(new Rectangle(128, 256, 32, 32)));
            worldTextures.Add("wallCornerRightTop", GetTile(new Rectangle(192, 256, 32, 32)));
            worldTextures.Add("wallCornerLeftTopEnding", GetTile(new Rectangle(128, 288, 32, 32)));
            worldTextures.Add("wallCornerRightTopEnding", GetTile(new Rectangle(192, 288, 32, 32)));


            // Prop Textures
            worldTextures.Add("testprops", GetProp(new Rectangle(0, 0, 32, 32)));
            worldTextures.Add("ComputerON", GetProp(new Rectangle(0, 62, 32, 32)));
            worldTextures.Add("ComputerOFF", GetProp(new Rectangle(0, 94, 32, 32)));
            worldTextures.Add("MonitorOFF", GetProp(new Rectangle(9, 169, 47, 22)));
            worldTextures.Add("greenStain", GetProp(new Rectangle(0, 32, 32, 32)));
            worldTextures.Add("greenStain_2", GetProp(new Rectangle(32, 32, 32, 32)));
            worldTextures.Add("waterStain", GetProp(new Rectangle(96, 32, 32, 32)));
            worldTextures.Add("waterStain_2", GetProp(new Rectangle(128, 32, 32, 32)));
            worldTextures.Add("gate_small_locked", GetProp(new Rectangle(0, 544, 32, 32)));
            worldTextures.Add("gate_small_locked_1", GetProp(new Rectangle(64, 544, 32, 32)));
            worldTextures.Add("gate_small_locked_2", GetProp(new Rectangle(96, 544, 32, 32)));
            worldTextures.Add("gate_small_locked_3", GetProp(new Rectangle(128, 544, 32, 32)));
            worldTextures.Add("chest_locked", GetProp(new Rectangle(352, 191, 32, 32)));
            worldTextures.Add("chest_open", GetProp(new Rectangle(384, 191, 32, 32)));
            worldTextures.Add("chest_locked_1", GetProp(new Rectangle(416, 191, 32, 32)));
            worldTextures.Add("chest_unlocked_1", GetProp(new Rectangle(448, 191, 32, 32)));
        }

        public Texture2D GetProp(Rectangle box) 
        {
            Texture2D cropTexture = new Texture2D(graphicsDevice, box.Width, box.Height);
            Color[] data = new Color[box.Width * box.Height];
            props.GetData(0, box, data, 0, data.Length);
            cropTexture.SetData(data);
            return cropTexture;
        }

        public Texture2D GetTile(Rectangle box) //will split up sprite for easy use, code idea from https://gamedev.stackexchange.com/questions/35358/create-a-texture2d-from-larger-image
        {
            Texture2D cropTexture = new Texture2D(graphicsDevice, box.Width, box.Height);
            Color[] data = new Color[box.Width * box.Height];
            texture.GetData(0, box, data, 0, data.Length);
            cropTexture.SetData(data);
            return cropTexture;
        }
    }
}
