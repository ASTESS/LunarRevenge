using LunarRevenge.Scripts.Content;
using LunarRevenge.Scripts.Entitys;
using LunarRevenge.Scripts.World;
using LunarRevenge.Scripts.World.Textures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LunarRevenge
{
    public class LunarRevenge : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private ScreenManager screenManager;
        private SoundManager soundManager;

        public static LunarRevenge lunarRevenge;

        public LunarRevenge()
        {
            lunarRevenge = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic 
            IsFixedTimeStep = false; //fix's lag after a few minutes
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screenManager = new ScreenManager(this.Content, this.graphics, GraphicsDevice, spriteBatch);
            soundManager = new SoundManager(this.Content);
        }

        TimeSpan timer;
        private double secondcounter = 0;

        protected override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime;
            secondcounter += gameTime.ElapsedGameTime.TotalSeconds;

            // Display time in seconds to console
            //Console.WriteLine(timer.TotalSeconds);

            if (secondcounter >= 1d / 60) //updating game at 60fps
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                screenManager.Update(gameTime);
                secondcounter = 0;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            screenManager.Draw(gameTime);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
