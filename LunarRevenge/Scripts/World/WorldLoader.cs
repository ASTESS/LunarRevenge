using LunarRevenge.Scripts.World.Textures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LunarRevenge.Scripts.World
{
    class WorldLoader
    {
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
        {"","floor","floor","floor","floor","floor","floor","floorQuadTile","floorCenter","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","","","","","","","","","" ,"" },
        };

        public static string[,] obstacles = new string[11, 11] {
            {"","","","","","","","","","","", },
            {"","waterTopLeft","waterBottomLeft","","","","","","","","", },
            {"","waterTopMiddle","waterBottomMiddle","waterBottomMiddle","","","","","","","", },
            {"","waterTopRight","waterBottomRight","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
        };

        public static string[,] walls = new string[11, 11] {
            {"","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","wallRightSide","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopRight","wallRightSide","wallRightSide","wallRightSide","wallRightSide","wallRightSide","wallRightSide","wallRightSide","wallRightSide","wallRightSide","wallRightSide", },
            {"","","","","","","","","","","", },
        };

        public List<Rectangle> rectangles = new List<Rectangle>();

        private bool loaded = false;
        public WorldLoader(TextureManager textureManager)
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
            int offset = 100;
            if (!loaded)
            {
                for (int x = 0; x < walls.GetLength(1); x++)
                {
                    for (int y = 0; y < walls.GetLength(0); y++)
                    {
                        string floorKey = floorMap[x, y];
                        string obstacleKey = obstacles[x, y];
                        string wallKey = walls[x, y];
                        if (textureManager.worldTextures.ContainsKey(floorKey)) //makes sure everything exist and can load empty squires
                        {
                            spriteBatch.Draw(textureManager.worldTextures[floorKey], new Vector2(offset + (x * 32), offset + (y * 32)), Color.White);
                        }
                        if (textureManager.worldTextures.ContainsKey(obstacleKey))
                        {
                            spriteBatch.Draw(textureManager.worldTextures[obstacleKey], new Vector2(offset + (x * 32), offset + (y * 32)), Color.White);
                        }
                        if (textureManager.worldTextures.ContainsKey(wallKey))
                        {
                            spriteBatch.Draw(textureManager.worldTextures[wallKey], new Vector2(offset + (x * 32), offset + (y * 32)), Color.White);
                            if (wallKey == "wallRightSide") {
                                rectangles.Add(new Rectangle(offset + 24 + (x * 32), offset + (y * 32), 8, 32));
                            }if (wallKey == "wallTopMiddle") {
                                rectangles.Add(new Rectangle(offset + (x * 32), offset + 16 + (y * 32), 32, 10));
                            } 
                        }
                    }
                }
                loaded = false;
            }
        }
    }
}
