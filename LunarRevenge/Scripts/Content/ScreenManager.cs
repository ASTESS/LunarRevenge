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
            levelSelect,
            death
        }

        private StartScreen startScreen;
        private KeyBinding keyBinding;
        private PauseScreen pauseScreen;
        public LevelScreen levelScreen;
        private LevelSelectionScreen levelSelectionScreen;
        private DeathScreen deathScreen;

        private ContentManager content;
        private GraphicsDeviceManager graphics;
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;



        public ScreenStates state = ScreenStates.home;
        public static ButtonState lastState = ButtonState.Released;

        public Level level;
        public ReadLevel readLevel;

        public ScreenManager(ContentManager content, GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            this.content = content;
            this.graphics = graphics;
            this.graphicsDevice = graphicsDevice;
            this.spriteBatch = spriteBatch;
            this.readLevel = new ReadLevel();
            init();
        }

        private void init()
        {
            startScreen = new StartScreen(this, content, graphicsDevice);
            keyBinding = new KeyBinding();
            pauseScreen = new PauseScreen(this, content, graphicsDevice);
            levelSelectionScreen = new LevelSelectionScreen(content, this, graphicsDevice, graphics);
            deathScreen = new DeathScreen(this);
        }

        public void changeState(ScreenStates states)
        {
            state = states;
        }

        public void Update(GameTime gameTime)
        {
            keyBinding.Update(this, graphics);

            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                lastState = ButtonState.Released;
            }

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
            }else if (state == ScreenStates.death)
            {
                deathScreen.Update();
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
            }else if (state == ScreenStates.death)
            {
                deathScreen.Draw(spriteBatch);
            }
        }
    }
}
