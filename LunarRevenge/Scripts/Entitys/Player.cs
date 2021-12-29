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
        public static Vector2 offset = new Vector2(0, 0);
        public Player(Texture2D texture, WorldLoader world, GraphicsDeviceManager graphics) : base(texture, world)
        {
            pos = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2); //stating position
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardInput();
            base.Update(gameTime);
        }

        private void KeyboardInput()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.GetPressedKeys().Length > 0)
            {
                this.state = EntityState.running;
            }
            else
            {
                this.state = EntityState.idle;
            }

            if (state.IsKeyDown(Keys.Z) || state.IsKeyDown(Keys.Up))
            {
                MovePlayer(Direction.up);
            }
            if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down))
            {
                MovePlayer(Direction.down);
            }
            if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
            {
                MovePlayer(Direction.right);
            }
            if (state.IsKeyDown(Keys.Q) || state.IsKeyDown(Keys.Left))
            {
                MovePlayer(Direction.left);
            }
        }

        private void MovePlayer(Direction direction)
        {
            if (collisionCheck(direction))
            {
                if (direction == Direction.up)
                {
                    offset.Y += speed;
                }
                if (direction == Direction.down)
                {
                    offset.Y -= speed;
                }
                if (direction == Direction.right)
                {
                    flip = SpriteEffects.None;
                    offset.X -= speed;

                }
                if (direction == Direction.left)
                {
                    flip = SpriteEffects.FlipHorizontally;
                    offset.X += speed;

                }
            }
        }
    }
}
