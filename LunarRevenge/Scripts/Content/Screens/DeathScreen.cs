using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Content.Screens
{
    internal class DeathScreen
    {
        ScreenManager screenManager;
        public DeathScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }
        public void Update()
        {
            int x = Mouse.GetState().Position.X;
            int y = Mouse.GetState().Position.Y;

            if (ScreenManager.lastState == ButtonState.Released)
            {
                /*if (x >= resumeButtonPos.X && x <= resumeButtonPos.X + resumeButton.Width * 0.2f &&
                    y >= resumeButtonPos.Y && y <= resumeButtonPos.Y + resumeButton.Height * 0.2f &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    ScreenManager.lastState = ButtonState.Pressed;
                    screenManager.changeState(ScreenManager.ScreenStates.level);
                }*/
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
