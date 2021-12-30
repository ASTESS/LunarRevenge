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

        public float health = 100;
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
        public int frames;


        private int currentX;
        int timeFromPreFrame = 0;

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
            collisionBox = new Rectangle(((int)pos.X - width / 2) + 10, ((int)pos.Y - height / 2) + 15, width - 14, height - 14);
        }

        public virtual void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, GameTime gameTime)
        {
            if (state == EntityState.idle)
            {
                startingX = 0;
                startingY = 0;
                width = 32;
                height = 32;
                frames = 2;
                currentX = startingX;
            }
            if (state == EntityState.running)
            {
                startingX = 0;
                startingY = 96;
                width = 32;
                height = 32;
                frames = 4;
            }
            if (state == EntityState.shooting)
            {
                startingX = 0;
                startingY = 128;
                width = 32;
                height = 32;
                frames = 4;
            }
            if (state == EntityState.reloading)
            {
                startingX = 0;
                startingY = 64;
                width = 32;
                height = 32;
                frames = 5;
            }
            if (state == EntityState.death)
            {
                startingX = 0;
                startingY = 160;
                width = 32;
                height = 32;
                frames = 7;
            }

            timeFromPreFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeFromPreFrame > 150)
            {
                timeFromPreFrame -= 150;
                if (frames > 1)
                {
                    currentX += width;
                    if (32 * (frames - 1) < currentX)
                    {
                        currentX = startingX;
                    }
                }
            }
            //spriteBatch.Draw(texture, pos, new Rectangle(startingX, startingY, width, height), Color.White
            spriteBatch.Draw(texture, pos, new Rectangle(currentX, startingY, width, height), Color.White, 0f, new Vector2(width/2, height/2), 1f, flip, 1f);


            //for testing collision boxes
            Texture2D rect = new Texture2D(graphics, 80, 30);
            Color[] data = new Color[80 * 30];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            rect.SetData(data);

            foreach (Rectangle item in world.rectangles)
            {
                spriteBatch.Draw(rect, item, Color.White);
            }

            Texture2D rect2 = new Texture2D(graphics, 80, 30);
            Color[] data2 = new Color[80 * 30];
            for (int i = 0; i < data2.Length; ++i) data2[i] = Color.Red;
            rect2.SetData(data2);
            //spriteBatch.Draw(rect2, collisionBox, Color.White);
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
                    flip = SpriteEffects.FlipHorizontally; // Turn character to the left
                }
                if (direction == Direction.right)
                {
                    pos.X += speed;
                    flip = SpriteEffects.None; // Turn Character to the right
                }
            }       
        }

        public bool collisionCheck(Direction direction) //collisoon check for now untile walls are introduced
        {
            foreach (Rectangle rec in world.rectangles)
            {
                if (rec.Right >= collisionBox.Right &&
                    rec.Left + 6 <= collisionBox.Right &&
                    rec.Bottom + 16 >= collisionBox.Bottom &&
                    rec.Top - 16 <= collisionBox.Top &&
                    direction == Direction.right)
                {
                    return false;
                }
                if (rec.Left <= collisionBox.Left &&
                    rec.Right >= collisionBox.Left &&
                    rec.Bottom + 16 >= collisionBox.Bottom &&
                    rec.Top - 16 <= collisionBox.Top &&
                    direction == Direction.left)
                {
                    return false;
                }
                if (rec.Bottom >= collisionBox.Top &&
                    rec.Top <= collisionBox.Top
                    && rec.Right + 16 >= collisionBox.Right &&
                    rec.Left - 10 <= collisionBox.Left &&
                    direction == Direction.up)
                {
                    return false;
                }
                if (rec.Top <= collisionBox.Bottom &&
                    rec.Bottom >= collisionBox.Bottom
                    && rec.Right + 16 >= collisionBox.Right &&
                    rec.Left - 10 <= collisionBox.Left &&
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
