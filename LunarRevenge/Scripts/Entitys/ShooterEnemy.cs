using LunarRevenge.Scripts.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Entitys
{
    internal class ShooterEnemy : Entity
    {
        private Vector2 postition = new Vector2(200, 1100);
        public ShooterEnemy(Texture2D texture, WorldLoader world) : base(texture, world)
        {
            this.health = 50;
            speed = 1f;
        }

        private Direction direction = Direction.right;
        public override void Update(GameTime gameTime)
        {
            
            pos = new Vector2(postition.X + Player.offset.X, postition.Y + Player.offset.Y);
            Console.WriteLine(pos);
            collisionBox = new Rectangle(((int)pos.X - width / 2) + 10, ((int)pos.Y - height / 2) + 15, width - 14, height - 14);
            if (!collisionCheck(direction))
            {
                if (direction == Direction.left)
                {
                    direction = Direction.right;
                }else if (direction == Direction.right)
                {
                    direction = Direction.left;
                }
            }
            state = EntityState.running;
            MoveEnemy(direction);
        }

        public void MoveEnemy(Direction direction)
        {
            if (collisionCheck(direction))
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
                    flip = SpriteEffects.FlipHorizontally; // Turn character to the left
                }
                if (direction == Direction.right)
                {
                    postition.X += speed;
                    flip = SpriteEffects.None; // Turn Character to the right
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, GameTime gameTime)
        {
            Animation(gameTime);
            //spriteBatch.Draw(texture, pos, new Rectangle(startingX, startingY, width, height), Color.White
            spriteBatch.Draw(texture, pos, new Rectangle(currentX, startingY, width, height), Color.White, 0f, new Vector2(width / 2, height / 2), 1f, flip, 1f);
        }

        public override void Animation(GameTime gameTime)
        {
            if (state == EntityState.idle)
            {
                startingX = 0;
                startingY = 384;
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
                startingY = 448;
                width = 32;
                height = 32;
                frames = 4;
                duration = 240;
            }
            if (state == EntityState.death)
            {
                startingX = 0;
                startingY = 480;
                width = 32;
                height = 32;
                frames = 8;
                duration = 150;
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
                    }
                }
            }
        }
    }
}
