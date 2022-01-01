using LunarRevenge.Scripts.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Entitys
{
    class Player : Entity
    {
        public static Vector2 offset = new Vector2(-200, -1000);
        public Player(Texture2D texture, WorldLoader world, GraphicsDeviceManager graphics) : base(texture, world)
        {
            pos = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2); //stating position
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardInput(gameTime);
            base.Update(gameTime);
        }

        private bool shooting = false;
        private int shootingTimer;

        private bool reloading = false;
        private int reloadingTimer;

        private void shoot(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && bullets > 0)
            {
                this.state = EntityState.shooting;
                shooting = true;
                
            }

            if (shooting)
            {
                shootingTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (shootingTimer > 150) //delay needs to be changed to animation duration
                {
                    shootingTimer -= 150;
                    if (frames > 1)
                    {
                        shooting = false;
                        bullets--;
                    }
                }
            }
        }

        private void Reload(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.R) && !reloading)
            {
                reloading = true;
                state = EntityState.reloading;
            }


            if (reloading)
            {
                reloadingTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (reloadingTimer > 150)
                {
                    reloadingTimer -= 150;
                    if (frames > 1)
                    {
                        reloading = false;
                        bullets = 26;
                    }
                }
            }
        }

        private void DamagePlayer()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                health = 0;
                state = EntityState.death;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.J))
            {
                health = 100;
            }
        }

        private void KeyboardInput(GameTime gameTime)
        {
            DamagePlayer();

            if (health > 0)
            {
                KeyboardState state = Keyboard.GetState();

                Reload(gameTime);
                if (!reloading)
                {
                    shoot(gameTime);
                    if (!shooting)
                    {
                        if (state.GetPressedKeys().Length > 0 && !shooting && !reloading)
                        {
                            this.state = EntityState.running;
                        }
                        else if (!shooting && !reloading)
                        {
                            this.state = EntityState.idle;
                        }
                    }
                }

                if (state.IsKeyDown(Keys.Z) || state.IsKeyDown(Keys.Up))
                {
                    MovePlayer(Direction.up);
                }
                if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down))
                {
                    MovePlayer(Direction.down);
                }
                if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
                {
                    MovePlayer(Direction.right);
                }
                if (state.IsKeyDown(Keys.Q) || state.IsKeyDown(Keys.Left))
                {
                    MovePlayer(Direction.left);
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
                frames = 2;
                currentX = startingX;
                duration = 150;
            }
            if (state == EntityState.running)
            {
                startingX = 0;
                startingY = 96;
                width = 32;
                height = 32;
                frames = 4;
                duration = 150;
            }
            if (state == EntityState.shooting)
            {
                startingX = 0;
                startingY = 128;
                width = 32;
                height = 32;
                frames = 4;
                duration = 240;
            }
            if (state == EntityState.reloading)
            {
                startingX = 0;
                startingY = 64;
                width = 32;
                height = 32;
                frames = 5;
                duration = 240;
            }
            if (state == EntityState.death)
            {
                startingX = 0;
                startingY = 160;
                width = 32;
                height = 32;
                frames = 7;
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

        private void MovePlayer(Direction direction)
        {
            if (collisionCheck(direction))
            {
                if (direction == Direction.up)
                {
                    offset.Y += speed;
                }
                if (direction == Direction.down)
                {
                    offset.Y -= speed;
                }
                if (direction == Direction.right)
                {
                    flip = SpriteEffects.None;
                    offset.X -= speed;

                }
                if (direction == Direction.left)
                {
                    flip = SpriteEffects.FlipHorizontally;
                    offset.X += speed;

                }
            }
        }
    }
}
