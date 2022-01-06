using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LunarRevenge.Scripts.World;
using LunarRevenge.Scripts.Items.Weapons;
using LunarRevenge.Scripts.Content.Screens;

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
        public string name;
        public Vector2 Location;

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

        private Texture2D markers;

        public void damageEntity(float damage)
        {
            Console.WriteLine("dead");
            health -= damage;
            if (health <= 0) // player died
            {
                health = 0;
                state = EntityState.death;
            }
        }

        public double Distance(Entity e1)
        {
            Vector2 e2 = this.pos;
            double distance = Math.Sqrt((Math.Pow(e1.pos.X - e2.X, 2) + Math.Pow(e1.pos.Y - e2.Y, 2)));
            return distance;
        }

        public Entity(Texture2D texture, Collision collision, string name)
        {
            this.collision = collision;
            this.texture = texture;
            this.name = name;
            markers = LevelScreen.content.Load<Texture2D>("Props and Items/props and items x1");
        }

        public virtual void Update(GameTime gameTime)
        {
            collisionBox = new Rectangle(((int)pos.X - width / 2) + 10, ((int)pos.Y - height / 2) + 15, width - 14, height - 14);

            for(int e = 0; e < projectiles.Count; e++)
            { 
                projectiles[e].Update();
                if (!collision.collisionCheck(projectiles[e].direction, projectiles[e].collisionBox))
                {
                    projectiles.RemoveAt(e);
                }else if (!collision.collisionCheck(projectiles[e].collisionBox))
                {
                    projectiles.RemoveAt(e);
                }   
            }
        }

        public virtual void Animation(GameTime gameTime)
        {
            
        }

        List<Projectile> projectiles = new List<Projectile>();

        public void Shoot(int damage, Vector2 pos)
        {
            Direction direct;
            if (flip == SpriteEffects.None)
            {
                direct = Direction.right;
            }
            else {
                direct = Direction.left;               
            }
            projectiles.Add(new Projectile(damage, direct, pos, collision));
        }

        public virtual void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, GameTime gameTime)
        {
            Animation(gameTime);
            //spriteBatch.Draw(texture, pos, new Rectangle(startingX, startingY, width, height), Color.White
            spriteBatch.Draw(texture, pos, new Rectangle(currentX, startingY, width, height), Color.White, 0f, new Vector2(width/2, height/2), 1f, flip, 1f);

            DebugCollisionMode(false, spriteBatch, graphics);

            foreach (Projectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch, graphics, gameTime);
            }

            if (this.GetType() != typeof(Player) && this.GetType() != typeof(Gate))
            {
                DrawMarker(spriteBatch, graphics);
            }
        }

        private void DrawMarker(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            Texture2D rect2 = new Texture2D(graphics, 80, 30);
            Color[] data2 = new Color[80 * 30];
            for (int i = 0; i < data2.Length; ++i) data2[i] = Color.Red;
            rect2.SetData(data2);

            spriteBatch.Draw(markers, new Vector2(pos.X - 4, pos.Y - 20), new Rectangle(268, 233, 8, 8), Color.White);
        }

        public void DebugCollisionMode(bool condition, SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            if (condition)
            {
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

                for (int e = 0; e < projectiles.Count; e++)
                {
                    spriteBatch.Draw(rect, projectiles[e].collisionBox, Color.White);
                }
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
