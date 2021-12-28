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
        {"","","","floorVentGreen","floor","floor","floor","floor","floor","floor" ,"" },
        {"","","","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floorQuadTile","floorCenter","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","","","","","","","","","" ,"" }
        };

        public static string[,] props = new string[11, 11] {            
            {"ComputerOFF","ComputerON","MonitorOFF","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", }
        };

        public static string[,] obstacles = new string[11, 11] {
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
            {"","","","","","","","","","","", }
        };

        public static string[,] walls = new string[11, 11] {
            {"","","","","","","","","","","", },
            {"wallTopLeft","wallLeftSide","wallLeftSide","wallLeftSide","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","wallBottomMiddle","", },
            {"wallTopMiddle","","","","","wallLeftSide","","","","wallBottomMiddle","", },
            {"wallTopMiddle","","","","","wallRightSide","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopRight","wallRightSide","wallRightSide","wallRightSide","wallRightSide","wallRightSide","wallCornerRightTopEnding","wallRightSide","wallRightSide","wallRightSide","wallRightSide", },
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
                        string propKey = props[x, y];

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

                            if (wallKey == "wallRightSide" ||
                                wallKey == "wallTopRight") 
                            {
                                rectangles.Add(new Rectangle(offset + 24 + (x * 32), offset + (y * 32), 8, 32));
                            }
                            
                            if (wallKey == "wallTopMiddle" ||
                                wallKey == "wallBottomMiddle" ||
                                wallKey == "wallTopRight" ||
                                wallKey == "wallTopLeft") 
                            {
                                rectangles.Add(new Rectangle(offset + (x * 32), offset + 16 + (y * 32), 32, 10));
                                rectangles.Add(new Rectangle(offset + (x * 32), offset + (y * 32), 32, 10));
                            }

                            if (wallKey == "wallLeftSide" ||
                                wallKey == "wallTopLeft")
                            {
                                rectangles.Add(new Rectangle(offset + (x * 32), offset + (y * 32), 8, 32));
                            }

                        }
                        if (textureManager.worldTextures.ContainsKey(propKey))
                        {
                            spriteBatch.Draw(textureManager.worldTextures[propKey], new Vector2(offset + (x * 32), offset + (y * 32)), Color.White);
                        }
                    }
                }
                loaded = false;
            }
        }
    }
}
