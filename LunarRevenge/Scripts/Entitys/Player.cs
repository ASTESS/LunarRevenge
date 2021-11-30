using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Entitys
{
    class Player : Entity
    {
        public Player(Texture2D texture) : base(texture)
        {
            pos = new Vector2(50,50); //stating position
        }

        public override void Update(GameTime gameTime)
        {
            speed = collisionCheck();
            if (Keyboard.GetState().IsKeyDown(Keys.Z) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                pos.Y -= speed ;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                pos.Y += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                pos.X += speed;
                flip = SpriteEffects.None; //look right
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                pos.X -= speed;
                flip = SpriteEffects.FlipHorizontally; //look left
            }
            base.Update(gameTime);
        }
    }
}
