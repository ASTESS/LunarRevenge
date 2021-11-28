using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LunarRevenge.NewFolder
{
    class Entity : Game1
    {
        Texture2D texture;

        int schuifOpX = 0;
        int schuifOpY = 0;

        string state;

        public Entity(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Update()
        {
            if (state == "idle")
            {
                schuifOpX = 0;
                schuifOpY = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(texture, new Vector2(0,0), new Rectangle(0,0,100,100), Color.White);


            spriteBatch.End();
        }
    }
}
