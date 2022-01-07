﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        private Texture2D menuButton;
        private Vector2 menuButtonPos;

        private Texture2D youDied;
        private Vector2 youDiedPos;
        public DeathScreen(ScreenManager screenManager, ContentManager content, GraphicsDevice graphics)
        {
            this.screenManager = screenManager;
            menuButton = content.Load<Texture2D>("Menu/Menu Button");
            menuButtonPos = new Vector2((graphics.Viewport.Width / 2) - (menuButton.Width * 0.2f) / 2, 150);

            youDied = content.Load<Texture2D>("Menu/You died");
            youDiedPos = new Vector2((graphics.Viewport.Width / 2) - (menuButton.Width * 0.2f) / 2, 100);
        }
        public void Update()
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
                    screenManager.level = null;
                    screenManager.levelScreen = null;
                    screenManager.changeState(ScreenManager.ScreenStates.home);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuButton, menuButtonPos, new Rectangle(0, 0, menuButton.Width, menuButton.Height), Color.White, 0f, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1f);
            spriteBatch.Draw(youDied, youDiedPos, new Rectangle(30, 225, 600, 200), Color.White, 0f, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1f);
        }
    }
}