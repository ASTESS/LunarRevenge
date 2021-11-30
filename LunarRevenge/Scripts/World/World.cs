using LunarRevenge.Scripts.World.Textures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LunarRevenge.Scripts.World
{
    class World
    {
        List<WorldSprite> worldSprites = new List<WorldSprite>();
        private TextureManager textureManager;

        string[,] floorMap = new string[11, 11] {
        {"","","","","","","","","","" ,"" },
        {"","","","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","","","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","","","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","","","","","","","","","" ,"" },
        };

        string[,] obstacles = new string[11, 11] {
            {"","","","","","","","","","","", },
            {"","waterTopLeft","waterBottomLeft","","","","","","","","", },
            {"","waterTopMiddle","waterBottomMiddle","","","","","","","","", },
            {"","waterTopRight","waterBottomRight","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
        };

        string[,] walls = new string[11, 11] {
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
        };

        private bool loaded = false;
        public World(TextureManager textureManager)
        {
            this.textureManager = textureManager;
        }
        public void Update(GameTime gametime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            renderMap(spriteBatch);
            /*
            spriteBatch.Draw(textureManager.worldTextures["floor"], new Vector2(100, 100), Color.White);
            spriteBatch.Draw(textureManager.worldTextures["floor"], new Vector2(133, 100), Color.White);
            spriteBatch.Draw(textureManager.worldTextures["floor"], new Vector2(133, 133), Color.White);
            spriteBatch.Draw(textureManager.worldTextures["floor"], new Vector2(100, 133), Color.White);*/
        }

        private void renderMap(SpriteBatch spriteBatch)
        {
            if (!loaded)
            {
                for (int x = 0; x < 11; x++)
                {
                    for (int y = 0; y < 11; y++)
                    {
                        string floorKey = floorMap[x, y];
                        string obstacleKey = obstacles[x, y];
                        string wallKey = walls[x, y];
                        if (textureManager.worldTextures.ContainsKey(floorKey)) //makes sure everything exist and can load empty squires
                        {
                            spriteBatch.Draw(textureManager.worldTextures[floorKey], new Vector2(100 + (x * 32), 100 + (y * 32)), Color.White);
                        }
                        if (textureManager.worldTextures.ContainsKey(obstacleKey))
                        {
                            spriteBatch.Draw(textureManager.worldTextures[obstacleKey], new Vector2(100 + (x * 32), 100 + (y * 32)), Color.White);
                        }
                        if (textureManager.worldTextures.ContainsKey(wallKey))
                        {
                            spriteBatch.Draw(textureManager.worldTextures[wallKey], new Vector2(100 + (x * 32), 100 + (y * 32)), Color.White);
                        }
                    }
                }
                loaded = false;
            }
        }
    }
}
