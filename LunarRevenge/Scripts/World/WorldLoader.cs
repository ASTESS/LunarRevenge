﻿using LunarRevenge.Scripts.Entitys;
using LunarRevenge.Scripts.World.Levels;
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



        public List<Rectangle> rectangles = new List<Rectangle>();
        ReadLevel levelRendering = new ReadLevel();


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
            rectangles.Clear();
            int offset = 352;
            if (!loaded)
            {
                int xMap = 0;
                int yMap = 0;
                for (int level = 0; level < levelRendering.lvl1.Levels.Length; level++)
                {
                    //for (int xMap = 0; xMap < /*levelRendering.lvl1.LevelSize*/ 9; xMap++)
                    //{
                    //for (int yMap = 0; yMap < /*levelRendering.lvl1.LevelSize*/ 9; yMap++)
                    //{
                    if (level%3 == 0)
                    {
                        xMap = 0;
                        yMap++;
                    }
                    
                    string[,] walls = levelRendering.lvl1.Levels[level].WallMapping;
                    string[,] floorMap = levelRendering.lvl1.Levels[level].FloorMapping;
                    string[,] props = levelRendering.lvl1.Levels[level].PropMapping;
                    string[,] obstacles = levelRendering.lvl1.Levels[level].ObstacleMapping;

                    for (int x = 0; x < /*levelRendering.lvl1.LevelSize*/walls.GetLength(0); x++)
                    {
                        for (int y = 0; y < /*levelRendering.lvl1.LevelSize*/walls.GetLength(1); y++)
                        {
                            string floorKey = floorMap[x, y];
                            string obstacleKey = obstacles[x, y];
                            string wallKey = walls[x, y];
                            string propKey = props[x, y];

                            if (textureManager.worldTextures.ContainsKey(floorKey)) //makes sure everything exist and can load empty squires
                            {
                                spriteBatch.Draw(textureManager.worldTextures[floorKey], new Vector2((offset * xMap) + (x * 32) + Player.offset.X, (offset * yMap) + (y * 32) + Player.offset.Y), Color.White);
                            }
                            if (textureManager.worldTextures.ContainsKey(obstacleKey))
                            {
                                spriteBatch.Draw(textureManager.worldTextures[obstacleKey], new Vector2((offset * xMap) + (x * 32) + Player.offset.X, (offset * yMap) + (y * 32) + Player.offset.Y), Color.White);
                            }
                            if (textureManager.worldTextures.ContainsKey(wallKey))
                            {
                                spriteBatch.Draw(textureManager.worldTextures[wallKey], new Vector2((offset * xMap) + (x * 32) + Player.offset.X, (offset * yMap) + (y * 32) + Player.offset.Y), Color.White);

                                if (wallKey == "wallRightSide" ||
                                    wallKey == "wallTopRight")
                                {
                                    rectangles.Add(new Rectangle((int)((offset * xMap) + 24 + (x * 32) + Player.offset.X), (int)((offset * yMap) + (y * 32) + Player.offset.Y), 8, 32));
                                }

                                if (wallKey == "wallTopMiddle" ||
                                    wallKey == "wallBottomMiddle" ||
                                    wallKey == "wallTopRight" ||
                                    wallKey == "wallTopLeft" ||
                                    wallKey == "wallBottomLeft" ||
                                    wallKey == "wallBottomRight"
                                    )
                                {
                                    rectangles.Add(new Rectangle((int)((offset * xMap) + (x * 32) + Player.offset.X), (int)((offset * yMap) + 16 + (y * 32) + Player.offset.Y), 32, 10));
                                    rectangles.Add(new Rectangle((int)((offset * xMap) + (x * 32) + Player.offset.X), (int)((offset * yMap) + (y * 32) + Player.offset.Y), 32, 10));
                                }

                                if (wallKey == "wallLeftSide" ||
                                    wallKey == "wallTopLeft" ||
                                    wallKey == "wallLeftSideEndBottom" ||
                                    wallKey == "wallLeftSideEndTop"
                                    )
                                {
                                    rectangles.Add(new Rectangle((int)((offset * xMap) + (x * 32) + Player.offset.X), (int)((offset * yMap) + (y * 32) + Player.offset.Y), 8, 32));
                                }

                                if (wallKey == "wallCornerRightTopEnding")
                                {
                                    rectangles.Add(new Rectangle((int)((offset * xMap) + (x * 32) + Player.offset.X), (int)((offset * yMap) + 16 + (y * 32) + Player.offset.Y), 32, 10));
                                    rectangles.Add(new Rectangle((int)((offset * xMap) + (x * 32) + Player.offset.X), (int)((offset * yMap) + (y * 32) + Player.offset.Y), 32, 10));
                                    rectangles.Add(new Rectangle((int)((offset * xMap) + 24 + (x * 32) + Player.offset.X), (int)((offset * yMap) + (y * 32) + Player.offset.Y), 8, 32));
                                    rectangles.Add(new Rectangle((int)((offset * xMap) + (x * 32) + Player.offset.X), (int)((offset * yMap) + (y * 32) + Player.offset.Y), 8, 26));
                                }

                            }
                            if (textureManager.worldTextures.ContainsKey(propKey))
                            {
                                spriteBatch.Draw(textureManager.worldTextures[propKey], new Vector2((offset * xMap) + (x * 32) + Player.offset.X, (offset * yMap) + (y * 32) + Player.offset.Y), Color.White);

                                if (propKey == "ComputerON")
                                {
                                    rectangles.Add(new Rectangle((int)((offset * xMap) + 3 + (x * 32) + Player.offset.X), (int)((offset * yMap) + 14 + (y * 32) + Player.offset.Y), 25, 16));
                                    rectangles.Add(new Rectangle((int)((offset * xMap) + 7 + (x * 32) + Player.offset.X), (int)((offset * yMap) + 4 + (y * 32) + Player.offset.Y), 14, 10));
                                }
                            }

                        }
                    }
                    xMap++;
                }
                loaded = false;
            }
        }
    }
}
