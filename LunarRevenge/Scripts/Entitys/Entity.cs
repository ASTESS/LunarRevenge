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

        public float collisionCheck() //collisoon check for now untile walls are introduced
        {
            if (pos.X < 0 + width)
            {
                pos.X += 0.1f;
                return 0f;
            }
            if (pos.Y < 0 + height)
            {
                pos.Y += 0.1f;
                return 0f;
            }
            return 5f;
        }
    }
}
