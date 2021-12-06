using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LunarRevenge.Scripts.World;

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

        private Rectangle collisionBox = Rectangle.Empty;

        protected float speed = 5f;

        protected Texture2D texture;
        protected WorldLoader world;

        public int startingX;
        public int startingY;
        public int width;
        public int height;

        public Entity(Texture2D texture, WorldLoader world)
        {
            this.texture = texture;
            this.world = world;
        }

        public virtual void Update(GameTime gameTime)
        {
            collisionBox = new Rectangle((int)pos.X - width / 2, (int)pos.Y - height / 2, width, height);
        }

        public virtual void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
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
            if(collisionCheck(direction)){ 
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
        }

        public bool collisionCheck(Direction direction) //collisoon check for now untile walls are introduced
        {
            Console.WriteLine(world.rectangles[0].Right +" : " + collisionBox.Right);
            foreach (Rectangle rec in world.rectangles)
            {
                if (rec.Left <= collisionBox.Right &&
                    rec.Right >= collisionBox.Right &&
                    rec.Bottom + 16 >= collisionBox.Bottom &&
                    rec.Top - 16 <= collisionBox.Top &&
                    direction == Direction.right)
                {
                    return false;
                }
                /*if (rec.Intersects(collisionBox)){
                    return false;
                }*/
            }
            return true;
        }
    }
}
