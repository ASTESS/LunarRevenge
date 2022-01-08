using LunarRevenge.Scripts.Content.Screens;
using LunarRevenge.Scripts.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Entitys
{
    internal class Sentinal : Entity
    {
        private Vector2 postition;
        private Vector2 Spawn;
        private Player Target;

        private bool activated = false;

        public Sentinal(Texture2D texture, Vector2 SpawnPoint, Collision collision, string name) : base(texture, collision, name)
        {
            this.health = 100;
            speed = 0.9f;
            postition = SpawnPoint;
            Spawn = SpawnPoint;
            Target = (Player)LevelScreen.entitys["player"];
        }

        private Direction direction = Direction.right;
        public override void Update(GameTime gameTime)
        {
            pos = new Vector2(postition.X + Player.offset.X, postition.Y + Player.offset.Y);
            if (!(state == EntityState.death))
            {
                if (this.Distance(Target) <= 175 && !NoticedTarget)
                {
                    NoticedTarget = true;
                    TimeOfNotice = gameTime.TotalGameTime.TotalSeconds;
                }

                if (NoticedTarget == false)
                {

                }
                else
                {
                    //shoot(10, new Vector2(Target.pos.X, pos.Y));
                }

                collisionBox = new Rectangle(((int)pos.X - width / 2) + 10, ((int)pos.Y - height / 2) + 15, width - 14, height - 14);

                //Console.WriteLine("P: " + (Target.pos.X - Player.offset.X) + " | E: " + (postition.X)); // positie van 

                if (NoticedTarget)
                {
                    if (!activated)
                    {
                        state = EntityState.activate;
                    }
                    
                }

                if (!collision.collisionCheck(direction, collisionBox))
                {
                    state = EntityState.idle;

                    
                }


                //state = EntityState.running;
                //MoveEntity(direction);
            }
            base.Update(gameTime);
        }

        // Moving the Entity
        public void MoveEntity(Direction direction)
        {
            if (collision.collisionCheck(direction, collisionBox))
            {
                if (direction == Direction.up)
                {
                    postition.Y -= speed;
                }
                if (direction == Direction.down)
                {
                    postition.Y += speed;
                }
                if (direction == Direction.left)
                {
                    postition.X -= speed;
                    flip = SpriteEffects.FlipHorizontally;
                }
                if (direction == Direction.right)
                {
                    postition.X += speed;
                    flip = SpriteEffects.None;
                }
            }
        }

        public override void Animation(GameTime gameTime)
        {
            if (state == EntityState.idle)
            {
                startingX = 0;
                if (activated)
                {
                    startingY = 192;
                }else
                {
                    startingY = 160;
                }
                
                width = 32;
                height = 32;
                frames = 1;
                currentX = startingX;
                duration = 150;
            }
            if (state == EntityState.running)
            {
                startingX = 0;
                startingY = 416;
                width = 32;
                height = 32;
                frames = 4;
                duration = 150;
            }
            if (state == EntityState.shooting)
            {
                startingX = 0;
                startingY = 288;
                width = 32;
                height = 32;
                frames = 4;
                duration = 240;
            }
            if (state == EntityState.death)
            {
                startingX = 0;
                startingY = 320;
                width = 32;
                height = 32;
                frames = 8;
                duration = 150;
            }
            if (state == EntityState.activate)
            {
                startingX = 0;
                startingY = 224;
                width = 32;
                height = 32;
                frames = 5;
                duration = 150;
                activated = true;
            }

            timeFromPreFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeFromPreFrame > duration)
            {
                timeFromPreFrame -= duration;
                if (frames > 1)
                {
                    currentX += width;
                    if (32 * (frames - 1) < currentX)
                    {
                        currentX = startingX;
                        if (activated && state == EntityState.activate)
                        {
                            state = EntityState.idle;
                        }

                        if (state == EntityState.death)
                        {
                            LevelScreen.entitys.Remove(name);
                        }
                    }
                }
            }
        }
    }
}
