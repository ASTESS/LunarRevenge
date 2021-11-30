using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LunarRevenge.Scripts.Entitys
{
    class Entity
    {
        public enum EntityState
        {
            idle,
            talking,
            reloading,
            running,
            shooting,
            death,
            activate
        }

        public enum Direction
        {
            up,
            down,
            left,
            right,
        }

        public float health;
        public Vector2 pos;
        public EntityState state = EntityState.idle;
        public SpriteEffects flip = SpriteEffects.None;

        protected float speed = 5f;

        protected Texture2D texture;

        public int startingX;
        public int startingY;
        public int width;
        public int height;

        public Entity(Texture2D texture)
        {
            this.texture = texture;
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //beginhoek van 30, 48      eindhoek van 66,96      60 tussen mannetjes
            if (state == EntityState.idle)
            {
                startingX = 10;
                startingY = 16;
                width = 12;
                height = 16;
            }
            //spriteBatch.Draw(texture, pos, new Rectangle(startingX, startingY, width, height), Color.White
            spriteBatch.Draw(texture, pos, new Rectangle(startingX, startingY, width, height), Color.White, 0f, new Vector2(width/2, height/2), 1f, flip, 1f);
        }

        public void Move(Direction direction)
        {
            if (direction == Direction.up)
            {
                pos.Y -= speed;
            }
            if (direction == Direction.down)
            {
                pos.Y += speed;
            }
            if (direction == Direction.left)
            {
                pos.X -= speed;
                flip = SpriteEffects.FlipHorizontally; //look left
            }
            if (direction == Direction.right)
            {
                pos.X += speed;
                flip = SpriteEffects.None; //look right
            }
        }

        public Vector2 collisionCheck(KeyboardState state, Vector2 newPos) //collisoon check for now untile walls are introduced
        {
            if (pos.X < 0 + width && (state.IsKeyDown(Keys.Q) || state.IsKeyDown(Keys.Left)))
            {
                //pos.X += 0.1f;
                return pos;
            }
            if (pos.Y < 0 + height && (state.IsKeyDown(Keys.Z) || state.IsKeyDown(Keys.Up)))
            {
                //pos.Y += 0.1f;
                return pos;
            }
            if (pos.Y > 100 - height && (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down)))
            {
                //pos.Y += 0.1f;
                return pos;
            }
            if (pos.X > 100 - width && (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Up)))
            {
                //pos.Y += 0.1f;
                return pos;
            }
            return newPos;
        }
    }
}
