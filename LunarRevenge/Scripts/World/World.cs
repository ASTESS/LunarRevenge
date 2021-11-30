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

        string[,] map = new string[10, 10] {
        {"floor","floor","floor","floor","floor","floor","floor","floor","floor","floor" },
        {"floor","floor","floor","floor","floor","floor","floor","floor","floor","floor" },
        {"floor","floor","floor","floor","floor","floor","floor","floor","floor","floor" },
        {"floor","floor","floor","floor","floor","floor","floor","floor","floor","floor" },
        {"floor","floor","floor","floor","floor","floor","floor","floor","floor","floor" },
        {"floor","floor","floor","floor","floor","floor","floor","floor","floor","floor" },
        {"floor","floor","floor","floor","floor","floor","floor","floor","floor","floor" },
        {"floor","floor","floor","floor","floor","floor","floor","floor","floor","floor" },
        {"floor","floor","floor","floor","floor","floor","floor","floor","floor","floor" },
        {"floor","floor","floor","floor","floor","floor","floor","floor","floor","floor" },
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
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        spriteBatch.Draw(textureManager.worldTextures[map[x,y]], new Vector2(x * 33, y * 33), Color.White);
                    }
                }
                loaded = false;
            }
        }
    }
}
