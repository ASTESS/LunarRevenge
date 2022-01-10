using LunarRevenge.Scripts.Content.Screens;
using LunarRevenge.Scripts.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LunarRevenge.Scripts.Entitys
{
    internal class Droid : Entity
    {
        private Vector2 postition = new Vector2(200, 1100);
        private Player Target;
        public Droid(Texture2D texture, Vector2 pos ,Collision collision, string name) : base(texture, collision, name)
        {
            this.health = 100;
            speed = 1f;
            postition = pos;
            Target = (Player)LevelScreen.entitys["player"];
        }

        private Direction direction = Direction.right;
        public override void Update(GameTime gameTime)
        {
            pos = new Vector2(postition.X + Player.offset.X, postition.Y + Player.offset.Y);
            if (!(state == EntityState.death))
            {
                collisionBox = new Rectangle(((int)pos.X - width / 2) + 10, ((int)pos.Y - height / 2) + 15, width - 14, height - 14);

                if (this.Distance(Target) <= 175 && !NoticedTarget)
                {
                    NoticedTarget = true;
                    TimeOfNotice = gameTime.TotalGameTime.TotalSeconds;
                }

                if (!collision.collisionCheck(direction, collisionBox))
                {
                    if (direction == Direction.left)
                    {
                        direction = Direction.right;
                    }
                    else if (direction == Direction.right)
                    {
                        direction = Direction.left;
                    }
                }

                if (NoticedTarget)
                {
                    if (postition.X >= (Target.pos.X - Player.offset.X))
                    {
                        flip = SpriteEffects.FlipHorizontally;
                    }
                    else if (postition.X <= (Target.pos.X - Player.offset.X))
                    {
                        flip = SpriteEffects.None;
                    }
                    if (postition.Y + 10 >= (Target.pos.Y - Player.offset.Y) && postition.Y - 10 <= (Target.pos.Y - Player.offset.Y) && state != EntityState.shooting)
                    {
                        Shoot(10, new Vector2(postition.X, postition.Y));
                    }
                }

                if (state != EntityState.shooting)
                {
                    state = EntityState.running;
                    MoveEntity(direction);
                }
                updateTimer(gameTime);
            }
            base.Update(gameTime);
        }

        float timer;
        private void updateTimer(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= 0.5f)
            {
                timer -= 0.5f;
                state = EntityState.running;
            }
        }

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
                    flip = SpriteEffects.FlipHorizontally; // Turn character to the left
                }
                if (direction == Direction.right)
                {
                    postition.X += speed;
                    flip = SpriteEffects.None; // Turn Character to the right
                }
            }
        }

        public override void Animation(GameTime gameTime)
        {
            if (state == EntityState.idle)
            {
                startingX = 0;
                startingY = 0;
                width = 32;
                height = 32;
                frames = 4;
                currentX = startingX;
                duration = 150;
            }
            if (state == EntityState.running)
            {
                startingX = 0;
                startingY = 32;
                width = 32;
                height = 32;
                frames = 4;
                duration = 150;
            }
            if (state == EntityState.shooting)
            {
                startingX = 0;
                startingY = 64;
                width = 32;
                height = 32;
                frames = 4;
                duration = 240;
            }
            if (state == EntityState.death)
            {
                startingX = 0;
                startingY = 96;
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
