using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.NewFolder
{
    class Player : Entity
    {
        public Player(Texture2D texture) : base(texture)
        {
            pos = new Vector2(0,0); //stating position
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                pos.Y -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                pos.Y += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                pos.X += speed;
                flip = SpriteEffects.None;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                pos.X -= speed;
                flip = SpriteEffects.FlipHorizontally;
            }
            base.Update(gameTime);
        }
    }
}
