using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Content
{
    internal class KeyBinding
    {
        private bool isPausedPressed = false;
        private bool isFullschreenPressed = false;
        public void Update(ScreenManager screenManager, GraphicsDeviceManager graphics)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.F) && !isFullschreenPressed)
            {
                isFullschreenPressed=true;
                graphics.ToggleFullScreen();

                //graphics.ApplyChanges();
            }else if (Keyboard.GetState().IsKeyUp(Keys.F))
            {
                isFullschreenPressed = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.P) && !isPausedPressed)
            {
                isPausedPressed = true;
                if (screenManager.state== ScreenManager.ScreenStates.paused)
                {
                    screenManager.changeState(ScreenManager.ScreenStates.level);
                }
                else if (screenManager.state != ScreenManager.ScreenStates.home)
                {
                    screenManager.changeState(ScreenManager.ScreenStates.paused);
                }
            }else if (Keyboard.GetState().IsKeyUp(Keys.P))
            {
                isPausedPressed = false;
            }
        }
    }
}
