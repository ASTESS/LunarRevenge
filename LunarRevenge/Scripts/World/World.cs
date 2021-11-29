using LunarRevenge.Scripts.World.Textures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.World
{
    class World
    {
        List<WorldSprite> worldSprites = new List<WorldSprite>();
        private TextureManager textureManager;

        public World(TextureManager textureManager)
        {
            this.textureManager = textureManager;
        }
        public void Update(GameTime gametime)
        {
            /*foreach (WorldSprite sprite in worldSprites)
            {
                sprite.Update(gametime);
            }*/
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureManager.worldTextures["floor"], new Vector2(50, 50), Color.White);
            spriteBatch.Draw(textureManager.worldTextures["floor"], new Vector2(149, 50), Color.White);
            spriteBatch.Draw(textureManager.worldTextures["floor"], new Vector2(149, 149), Color.White);
            spriteBatch.Draw(textureManager.worldTextures["floor"], new Vector2(50, 149), Color.White);
            /*foreach (WorldSprite sprite in worldSprites)
            {
                sprite.Draw(spriteBatch);
            }*/
        }
    }
}
