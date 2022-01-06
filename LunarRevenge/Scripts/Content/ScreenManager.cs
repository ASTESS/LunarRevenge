using LunarRevenge.Scripts.Content.Screens;
using LunarRevenge.Scripts.Entitys;
using LunarRevenge.Scripts.World;
using LunarRevenge.Scripts.World.Levels;
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
            levelSelect
        }

        private StartScreen startScreen;
        private KeyBinding keyBinding;
        private PauseScreen pauseScreen;
        public LevelScreen levelScreen;
        private LevelSelectionScreen levelSelectionScreen;

        private ContentManager content;
        private GraphicsDeviceManager graphics;
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;



        public ScreenStates state = ScreenStates.home;

        public Level level;
        public ReadLevel readLevel;

        public ScreenManager(ContentManager content, GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            this.content = content;
            this.graphics = graphics;
            this.graphicsDevice = graphicsDevice;
            this.spriteBatch = spriteBatch;
            this.readLevel = new ReadLevel();
            this.level = readLevel.lvl1;
            init();
        }

        private void init()
        {
            startScreen = new StartScreen(this, content, graphicsDevice);
            keyBinding = new KeyBinding();
            pauseScreen = new PauseScreen(this, content, graphicsDevice);
            levelSelectionScreen = new LevelSelectionScreen(content, this, graphicsDevice, graphics);
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
            }
            else if (state == ScreenStates.level)
            {
                levelScreen.Update(gameTime);
            }
            else if (state == ScreenStates.levelSelect)
            {
                levelSelectionScreen.Update(gameTime);
            }
            else if (state == ScreenStates.paused)
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
            else if (state == ScreenStates.levelSelect)
            {
                levelSelectionScreen.Draw(spriteBatch);
            }
            else if (state == ScreenStates.paused)
            {
                pauseScreen.Draw(graphicsDevice, spriteBatch);
            }
        }
    }
}
