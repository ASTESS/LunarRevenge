using LunarRevenge.Scripts.Content.Screens;
using LunarRevenge.Scripts.Entitys;
using LunarRevenge.Scripts.World;
using LunarRevenge.Scripts.World.Textures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Content
{
    internal class ScreenManager
    {
        public enum ScreenStates
        {
            home,
            level,
            paused,
        }

        private StartScreen startScreen;
        private KeyBinding keyBinding;
        private PauseScreen pauseScreen;
        private LevelScreen levelScreen;

        private ContentManager content;
        private GraphicsDeviceManager graphics;
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;



        public ScreenStates state = ScreenStates.home;

        public ScreenManager(ContentManager content, GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            this.content = content;
            this.graphics = graphics;
            this.graphicsDevice = graphicsDevice;
            this.spriteBatch = spriteBatch;
            init();
        }

        private void init()
        {
            startScreen = new StartScreen(this, content, graphicsDevice);
            keyBinding = new KeyBinding();
            pauseScreen = new PauseScreen(this, content, graphicsDevice);
            levelScreen = new LevelScreen(content, graphicsDevice, graphics);
        }

        public void changeState(ScreenStates states)
        {
            state = states;
        }

        public void Update(GameTime gameTime)
        {
            keyBinding.Update(this, graphics);

            if (state == ScreenStates.home)
            {
                startScreen.Update();
            }else if (state == ScreenStates.level)
            {
                levelScreen.Update(gameTime);
            }else if (state == ScreenStates.paused)
            {
                pauseScreen.Update();
            }
        }

        

        public void Draw(GameTime gameTime)
        {
            if (state == ScreenStates.home)
            {
                startScreen.Draw(spriteBatch);
            }
            else if (state == ScreenStates.level)
            {
                levelScreen.Draw(spriteBatch, gameTime);
            }
            else if (state == ScreenStates.paused)
            {
                pauseScreen.Draw(graphicsDevice, spriteBatch);
            }
        }
    }
}
