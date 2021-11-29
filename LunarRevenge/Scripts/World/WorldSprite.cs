using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LunarRevenge.Scripts.World
{
    internal class WorldSprite
    {
        protected Texture2D texture;

        public WorldSprite(Texture2D texture)
        {
            this.texture = texture;
        }
        public virtual void Update(GameTime gametime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(100,100), Color.White);
        }
    }
}
