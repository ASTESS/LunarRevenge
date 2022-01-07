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
        private int levelsUnlocked = 0;
        private Texture2D spriteSheet;
        private ScreenManager screenManager;
        private GraphicsDevice graphicsDevice;
        private GraphicsDeviceManager graphics;

        public LevelSelectionScreen(ContentManager content, ScreenManager screenManager, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics)
        {
            this.content = content;
            this.screenManager = screenManager;
            this.graphicsDevice = graphicsDevice;
            this.graphics = graphics;
            spriteSheet = content.Load<Texture2D>("Menu/Numbers");
        }

        private bool loadLevel = false;

        public void Update(GameTime gameTime)
        {
            int x = Mouse.GetState().Position.X;
            int y = Mouse.GetState().Position.Y;

            if (ScreenManager.lastState == ButtonState.Released)
            {
                if (x >= 103 && x <= 103 + 103 &&
                y >= 10 && y <= 10 + 103 &&
                Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    screenManager.level = screenManager.readLevel.lvl1;
                    loadLevel = true;
                }
                if (x >= 206 && x <= 206 + 103 &&
                    y >= 10 && y <= 10 + 103 &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    screenManager.level = screenManager.readLevel.lvl1;
                    loadLevel = true;
                }
                if (x >= 309 && x <= 309 + 103 &&
                    y >= 10 && y <= 10 + 103 &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    screenManager.level = screenManager.readLevel.lvl1;
                    loadLevel = true;
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
            spriteBatch.Draw(spriteSheet, new Vector2(103, 10), new Rectangle(103, 0, 103, 103), Color.White);
            spriteBatch.Draw(spriteSheet, new Vector2(206, 10), new Rectangle(206, 0, 103, 103), Color.White);
            spriteBatch.Draw(spriteSheet, new Vector2(309, 10), new Rectangle(309, 0, 103, 103), Color.White);
        }
    }
}
