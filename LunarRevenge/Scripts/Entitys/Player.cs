using LunarRevenge.Scripts.World;
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
        public Player(Texture2D texture, WorldLoader world) : base(texture, world)
        {
            pos = new Vector2(50,50); //stating position
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 newPos = pos;
            KeyboardState state = Keyboard.GetState();
            Keys key = Keys.None;

            if (state.IsKeyDown(Keys.Z) || state.IsKeyDown(Keys.Up))
            {
                Move(Direction.up);
            }
            if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down))
            {
                Move(Direction.down);
            }
            if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
            {
                Move(Direction.right);
            }
            if (state.IsKeyDown(Keys.Q) || state.IsKeyDown(Keys.Left))
            {
                Move(Direction.left);
            }
            base.Update(gameTime);
        }
    }
}
