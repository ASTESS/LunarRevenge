using LunarRevenge.Scripts.Content;
using LunarRevenge.Scripts.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Entitys
{
    class Player : Entity
    {
        public static Vector2 offset = new Vector2(0, 0);
        private int midX = 0;
        private int midY = 0;
        private Direction currentDirection;

        SoundEffect effect;
        SoundEffectInstance soundEffect;
        ScreenManager screenManager;

        SoundManager soundManager;

        public Player(Texture2D texture, GraphicsDeviceManager graphics, Collision collision, string name, ContentManager content, ScreenManager screenManager) : base(texture, collision, name)
        {
            midY = graphics.GraphicsDevice.Viewport.Height / 2;
            midX = graphics.GraphicsDevice.Viewport.Width / 2;
            pos = new Vector2(midX, midY); //stating position
            this.screenManager = screenManager;
            offset = new Vector2(0, 0);
            soundManager = new SoundManager(content);
            this.bullets = 0;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardInput(gameTime);

            if (!canTakeDamage)
            {
                updateTimer(gameTime);
            }

            base.Update(gameTime);
        }

        private bool shooting = false;
        private int shootingTimer;

        private bool reloading = false;
        private int reloadingTimer;

        private void shoot(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && bullets > 0 && !shooting)
            {
                // Player is shooting projectiles
                this.state = EntityState.shooting;
                shooting = true;
                Shoot(10, new Vector2(midX - offset.X, midY - offset.Y));
            }

            if (shooting)
            {
                shootingTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (shootingTimer > 150)
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
                damageEntity(10);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.J))
            {
                health = 100;
            }
        }

        public override void damageEntity(float damage)
        {
            if (canTakeDamage)
            {
                health -= damage;
                if (health <= 0) // player died
                {
                    health = 0;
                    state = EntityState.death;
                }
                else
                {
                    canTakeDamage = false;
                    state = EntityState.hurt;
                }
            }
        }

        float timer;
        private void updateTimer(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= 0.5f)
            {
                timer -= 0.5f;
                canTakeDamage = true;
                state = EntityState.idle;
            }
        }

        private bool playerIsJumping = false;
        private bool playerIsFalling = false;
        private float velocity = 0f;
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
                        if (state.IsKeyDown(Keys.Z) || state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.Q) || state.IsKeyDown(Keys.Left) && !shooting && !reloading)
                        {
                            this.state = EntityState.running;
                        }
                        else if (!shooting && !reloading && this.state != EntityState.hurt)
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
                if (state.IsKeyDown(Keys.Space))
                {
                    if (!playerIsJumping)
                    {
                        velocity = -0.5f;
                        playerIsJumping = true;
                        playerIsFalling = false;
                        soundEffect.Pause();
                    }
                }

                //240 == ground
                

                if (pos.Y == 230)
                {
                    velocity = 0.5f;
                    playerIsFalling = true;
                }

                if (pos.Y == 240 && playerIsFalling)
                {
                    playerIsJumping = false;
                    playerIsFalling = false;
                    velocity = 0f;
                }

                pos.Y += velocity;
                //Console.WriteLine($"F: {playerIsFalling} | J: {playerIsJumping}");
            }
        }

        public override void Animation(GameTime gameTime)
        {
            playSounds(gameTime);
            if (state == EntityState.idle)
            {
                startingX = 0;
                startingY = 0;
                width = 32;
                height = 32;
                frames = 2;
                currentX = startingX;
                duration = 150;
                soundEffect.Pause();
            }
            if (state == EntityState.running)
            {
                startingX = 0;
                startingY = 96;
                width = 32;
                height = 32;
                frames = 4;
                duration = 150;

                if(!playerIsJumping)
                    soundEffect.Play();
            }
            if (state == EntityState.shooting)
            {
                startingX = 0;
                startingY = 128;
                width = 32;
                height = 32;
                frames = 4;
                duration = 240;
                soundEffect.Pause();
            }
            if (state == EntityState.reloading)
            {
                startingX = 0;
                startingY = 64;
                width = 32;
                height = 32;
                frames = 5;
                duration = 240;
                soundEffect.Pause();
            }
            if (state == EntityState.death)
            {
                startingX = 0;
                startingY = 160;
                width = 32;
                height = 32;
                frames = 7;
                duration = 150;
                soundEffect.Pause();
            }
            if (state == EntityState.hurt)
            {
                Console.WriteLine("hurt");
                startingX = 0;
                startingY = 0;
                width = 32;
                height = 32;
                frames = 3;
                duration = 150;
                soundEffect.Pause();
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
                            screenManager.state = ScreenManager.ScreenStates.death;
                        }
                    }
                }
            }
        }

        Random random = new Random();
        private void playSounds(GameTime gameTime)
        {
            if (soundEffect == null) //for first launch
            {
                effect = soundManager.sfx[0];
                soundEffect = effect.CreateInstance();
            }

            if (soundEffect.State == SoundState.Stopped) //state is stopped
            {
                effect = soundManager.sfx[random.Next(0,8)];
                soundEffect = effect.CreateInstance();
                soundEffect.Play();
            }
        }

        private void MovePlayer(Direction direction)
        {
            currentDirection = direction;
            if (collision.collisionCheck(direction, collisionBox))
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

                Location = new Vector2((pos.X), (pos.Y));

            }
        }
    }
}
