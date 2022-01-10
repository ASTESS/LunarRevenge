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
            activate,
            hurt,
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

        public bool NoticedTarget = false;
        public double TimeOfNotice = 0.0;

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
        private int markerX;

        public bool canTakeDamage = true;

        public virtual void damageEntity(float damage)
        {
                health -= damage;
                if (health <= 0 && state != EntityState.death) // player died
                {
                    state = EntityState.death;
                    Player.score += 100;
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
            markers = LevelScreen.content.Load<Texture2D>("UI/UI x1");
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


        private int bulletOffset;
        public void Shoot(int damage, Vector2 pos)
        {
            Direction direct;
            if (flip == SpriteEffects.None)
            {
                bulletOffset = 20;
                direct = Direction.right;
            }
            else {
                bulletOffset = -20;
                direct = Direction.left;               
            }
            state = EntityState.shooting;
            projectiles.Add(new Projectile(damage, direct, new Vector2(pos.X + bulletOffset, pos.Y), collision));
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

            if (this.GetType() != typeof(Player) && this.GetType() != typeof(Gate) && this.GetType() != typeof(Acid))
            {
                DrawMarker(spriteBatch, graphics, gameTime);
            }
        }

        private void DrawMarker(SpriteBatch spriteBatch, GraphicsDevice graphics, GameTime gameTime)
        {
            if (NoticedTarget && (TimeOfNotice + 3 >= gameTime.TotalGameTime.TotalSeconds))
            {
                spriteBatch.Draw(markers, new Vector2(pos.X - 4, pos.Y - 20), new Rectangle(106, 299, 10, 10), Color.White);
            }
            else
            {
                // Draw Health bar of the Entity
                if (this.health <= 0) { markerX = 40; }
                else if (this.health <= 15) { markerX = 72; }
                else if (this.health <= 35) { markerX = 104; }
                else if (this.health <= 50) { markerX = 136; }
                else if (this.health <= 65) { markerX = 168; }
                else if (this.health <= 90) { markerX = 200; }
                else { markerX = 232; }
                spriteBatch.Draw(markers, new Vector2(pos.X - 7, pos.Y - 20), new Rectangle(markerX, 173, 16, 6), Color.White);
            }
        }

        public void DebugCollisionMode(bool condition, SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            if (condition)
            {
                Texture2D wallsCollisonBox = new Texture2D(graphics, 80, 30);
                Color[] wallsCollisonBoxData = new Color[80 * 30];
                for (int i = 0; i < wallsCollisonBoxData.Length; ++i) wallsCollisonBoxData[i] = Color.Chocolate;
                wallsCollisonBox.SetData(wallsCollisonBoxData);

                foreach (Rectangle item in collision.world.rectangles)
                {
                    spriteBatch.Draw(wallsCollisonBox, item, Color.White);
                }

                foreach (Rectangle item in collision.collisions)
                {
                    spriteBatch.Draw(wallsCollisonBox, item, Color.White);
                }

                Texture2D projectileCollisionBox = new Texture2D(graphics, 80, 30);
                Color[] projectileCollisionBoxData = new Color[80 * 30];
                for (int i = 0; i < projectileCollisionBoxData.Length; ++i) projectileCollisionBoxData[i] = Color.Red;
                projectileCollisionBox.SetData(projectileCollisionBoxData);

                for (int e = 0; e < projectiles.Count; e++)
                {
                    spriteBatch.Draw(projectileCollisionBox, projectiles[e].collisionBox, Color.White);
                }

                Texture2D acidCollisonBox = new Texture2D(graphics, 80, 30);
                Color[] acidCollisonBoxData = new Color[80 * 30];
                for (int i = 0; i < acidCollisonBoxData.Length; ++i) acidCollisonBoxData[i] = Color.Green;
                acidCollisonBox.SetData(acidCollisonBoxData);

                foreach (Acid acid in LevelScreen.specialTiles)
                {
                    spriteBatch.Draw(acidCollisonBox, acid.collisionBox, Color.White);
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
