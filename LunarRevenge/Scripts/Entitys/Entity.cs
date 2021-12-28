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

        private float health;
        public Vector2 pos;
        public EntityState state = EntityState.idle;
        public SpriteEffects flip = SpriteEffects.None;

        private Rectangle collisionBox = Rectangle.Empty;

        protected float speed = 2f;

        protected Texture2D texture;
        protected WorldLoader world;

        public int startingX;
        public int startingY;
        public int width;
        public int height;

        public void damageEntity(float damage)
        {
            health -= damage;
            if (health <= 0) // player died
            {
                health = 0;
                state = EntityState.death;
            }
        }

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

            Texture2D rect = new Texture2D(graphics, 80, 30);

            Color[] data = new Color[80 * 30];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            rect.SetData(data);

            /*foreach (Rectangle item in world.rectangles)
            {
                spriteBatch.Draw(rect, item, Color.White);
            }*/
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
            foreach (Rectangle rec in world.rectangles)
            {
                if (rec.Left <= collisionBox.Right &&
                    rec.Right >= collisionBox.Right &&
                    rec.Bottom + 8 >= collisionBox.Bottom &&
                    rec.Top - 8 <= collisionBox.Top &&
                    direction == Direction.right)
                {
                    return false;
                }
                if (rec.Left <= collisionBox.Left &&
                    rec.Right >= collisionBox.Left &&
                    rec.Bottom + 8 >= collisionBox.Bottom &&
                    rec.Top - 8 <= collisionBox.Top &&
                    direction == Direction.left)
                {
                    return false;
                }
                if (rec.Bottom >= collisionBox.Top &&
                    rec.Top <= collisionBox.Top
                    && rec.Right +8 >= collisionBox.Right &&
                    rec.Left - 8 <= collisionBox.Left &&
                    direction == Direction.up)
                {
                    return false;
                }
                if (rec.Top <= collisionBox.Bottom &&
                    rec.Bottom >= collisionBox.Bottom
                    && rec.Right + 8 >= collisionBox.Right &&
                    rec.Left - 8 <= collisionBox.Left &&
                    direction == Direction.down)
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
