using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LunarRevenge.Scripts.World;
using LunarRevenge.Scripts.Items.Weapons;

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
        public int bullets = 26;
        public Vector2 pos;
        public EntityState state = EntityState.idle;
        public SpriteEffects flip = SpriteEffects.None;

        public Rectangle collisionBox = Rectangle.Empty;

        public Collision collision;

        public float speed = 2f;

        protected Texture2D texture;

        public int startingX;
        public int startingY;
        public int width;
        public int height;
        public int frames;

        public int currentX;
        public int timeFromPreFrame = 0;
        public int duration;

        public void damageEntity(float damage)
        {
            health -= damage;
            if (health <= 0) // player died
            {
                health = 0;
                state = EntityState.death;
            }
        }

        public Entity(Texture2D texture, Collision collision)
        {
            this.collision = collision;
            this.texture = texture;
        }

        public virtual void Update(GameTime gameTime)
        {
            collisionBox = new Rectangle(((int)pos.X - width / 2) + 10, ((int)pos.Y - height / 2) + 15, width - 14, height - 14);

            for(int e = 0; e < projectiles.Count - 1; e++)
            {
                /*if (!collision.collisionCheck(projectiles[e].direction, projectiles[e].collisionBox))
                {
                    projectiles.RemoveAt(e);
                }*/
                projectiles[e].Update();
            }
        }

        public virtual void Animation(GameTime gameTime)
        {
            
        }


        List<Projectile> projectiles = new List<Projectile>();

        public void Shoot(int damage, Player.Direction direction, Vector2 pos)
        {
            projectiles.Add(new Projectile(damage, direction, pos));
        }

        public virtual void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, GameTime gameTime)
        {
            Animation(gameTime);
            //spriteBatch.Draw(texture, pos, new Rectangle(startingX, startingY, width, height), Color.White
            spriteBatch.Draw(texture, pos, new Rectangle(currentX, startingY, width, height), Color.White, 0f, new Vector2(width/2, height/2), 1f, flip, 1f);

            //for testing collision boxes
            Texture2D rect = new Texture2D(graphics, 80, 30);
            Color[] data = new Color[80 * 30];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            rect.SetData(data);

            foreach (Rectangle item in collision.world.rectangles)
            {
                spriteBatch.Draw(rect, item, Color.White);
            }

            Texture2D rect2 = new Texture2D(graphics, 80, 30);
            Color[] data2 = new Color[80 * 30];
            for (int i = 0; i < data2.Length; ++i) data2[i] = Color.Red;
            rect2.SetData(data2);
            spriteBatch.Draw(rect2, collisionBox, Color.White);

            foreach (Projectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch, graphics, gameTime);
            }
        }

        /*public void Move(Direction direction)
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
        }*/
    }
}
