using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Content.Screens
{
    internal class LevelSelectionScreen
    {
        private ContentManager content;
        private ScreenManager screenManager;
        private GraphicsDevice graphicsDevice;
        private GraphicsDeviceManager graphics;

        private Texture2D menuButton;
        private Vector2 menuButtonPos;

        public LevelSelectionScreen(ContentManager content, ScreenManager screenManager, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics)
        {
            this.content = content;
            this.screenManager = screenManager;
            this.graphicsDevice = graphicsDevice;
            this.graphics = graphics;
            menuButton = content.Load<Texture2D>("Menu/Menu Button");
            menuButtonPos = new Vector2((graphicsDevice.Viewport.Width / 2) - (menuButton.Width * 0.2f) / 2, 250);
        }

        private bool loadLevel = false;

        public void Update(GameTime gameTime)
        {
            int x = Mouse.GetState().Position.X;
            int y = Mouse.GetState().Position.Y;

            if (ScreenManager.lastState == ButtonState.Released)
            {
                if (x >= menuButtonPos.X && x <= menuButtonPos.X + menuButton.Width * 0.2f &&
                    y >= menuButtonPos.Y && y <= menuButtonPos.Y + menuButton.Height * 0.2f &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    ScreenManager.lastState = ButtonState.Pressed;
                    screenManager.changeState(ScreenManager.ScreenStates.home);
                }

                if (loadLevel)
                {
                    loadLevel = false;
                    screenManager.levelScreen = new LevelScreen(content, graphicsDevice, graphics, screenManager);
                    screenManager.levelScreen.Init();
                    screenManager.changeState(ScreenManager.ScreenStates.level);
                }
                
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuButton, menuButtonPos, new Rectangle(0, 0, menuButton.Width, menuButton.Height), Color.White, 0f, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1f);
        }
    }
}
