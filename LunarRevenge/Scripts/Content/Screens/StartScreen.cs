using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LunarRevenge.Scripts.Content
{
    internal class StartScreen
    {
        Rectangle startButton = new Rectangle(50, 50, 50, 50);
        ScreenManager screenManager;

        public StartScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        public void Update()
        {
            int x = Mouse.GetState().Position.X;
            int y = Mouse.GetState().Position.Y;
            if (x >= startButton.X && x <= startButton.X + startButton.Width &&
                y >= startButton.Y && y <= startButton.Y + startButton.Height &&
                Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                screenManager.changeState(ScreenManager.ScreenStates.level);
            }
        }

        public void Draw(GraphicsDevice graphics, SpriteBatch spriteBatch)
        {
            Texture2D rect2 = new Texture2D(graphics, 80, 30);
            Color[] data2 = new Color[80 * 30];
            for (int i = 0; i < data2.Length; ++i) data2[i] = Color.Red;
            rect2.SetData(data2);
            spriteBatch.Draw(rect2, startButton, Color.White);
        }
    }
}
