using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace LunarRevenge.Scripts.Content
{
    internal class StartScreen
    {
        //Rectangle startButton = new Rectangle(50, 50, 50, 50);
        ScreenManager screenManager;
        private GraphicsDevice graphics;


        private Texture2D startButton;
        private Vector2 startButtonPos;

        private Texture2D quitButton;
        private Vector2 quitButtonPos;

        private Texture2D resumeButton;
        private Vector2 resumeButtonPos;
        public StartScreen(ScreenManager screenManager, ContentManager content, GraphicsDevice graphics)
        {
            this.screenManager = screenManager;
            this.graphics = graphics;

            resumeButton = content.Load<Texture2D>("Menu/Resume Button");
            resumeButtonPos = new Vector2((graphics.Viewport.Width / 2) - (resumeButton.Width * 0.2f) / 2, 50);

            startButton = content.Load<Texture2D>("Menu/Start Button");
            startButtonPos = new Vector2((graphics.Viewport.Width / 2) - (startButton.Width*0.2f)/2, 100);

            quitButton = content.Load<Texture2D>("Menu/Quit Button");
            quitButtonPos = new Vector2((graphics.Viewport.Width / 2) - (quitButton.Width * 0.2f)/2, 150);
        }

        public void Update()
        {
            int x = Mouse.GetState().Position.X;
            int y = Mouse.GetState().Position.Y;
            if (x >= startButtonPos.X && x <= startButtonPos.X + startButton.Width * 0.2f &&
                y >= startButtonPos.Y && y <= startButtonPos.Y + startButton.Height * 0.2f &&
                Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                screenManager.changeState(ScreenManager.ScreenStates.level);
            }

            if (x >= quitButtonPos.X && x <= quitButtonPos.X + quitButton.Width * 0.2f &&
                y >= quitButtonPos.Y && y <= quitButtonPos.Y + quitButton.Height * 0.2f &&
                Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                LunarRevenge.lunarRevenge.Exit();
            }

            if (x >= resumeButtonPos.X && x <= resumeButtonPos.X + resumeButton.Width * 0.2f &&
                y >= resumeButtonPos.Y && y <= resumeButtonPos.Y + resumeButton.Height * 0.2f &&
                Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                screenManager.changeState(ScreenManager.ScreenStates.level);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(resumeButton, resumeButtonPos, new Rectangle(0, 0, resumeButton.Width, resumeButton.Height), Color.White, 0f, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1f);
            spriteBatch.Draw(startButton, startButtonPos, new Rectangle(0, 0, startButton.Width, startButton.Height), Color.White, 0f, new Vector2(0,0), 0.2f, SpriteEffects.None, 1f);
            spriteBatch.Draw(quitButton, quitButtonPos, new Rectangle(0, 0, quitButton.Width, quitButton.Height), Color.White, 0f, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1f);
        }
    }
}
