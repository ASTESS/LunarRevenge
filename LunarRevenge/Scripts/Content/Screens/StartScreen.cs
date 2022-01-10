using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using LunarRevenge.Scripts.Content.Screens;
using Microsoft.Xna.Framework.Audio;

namespace LunarRevenge.Scripts.Content
{
    internal class StartScreen
    {
        //Rectangle startButton = new Rectangle(50, 50, 50, 50);
        ScreenManager screenManager;
        private GraphicsDevice graphics;
        private GraphicsDeviceManager graphicsManager;
        private ContentManager content;
        SoundEffectInstance soundEffect;
        SoundManager soundManager;

        private Texture2D quitButton;
        private Vector2 quitButtonPos;

        private Texture2D resumeButton;
        private Vector2 resumeButtonPos;

        private Texture2D backGround;

        private Texture2D level1;
        private Texture2D level2;
        private Texture2D level3;

        private Vector2 level1Pos;
        private Vector2 level2Pos;
        private Vector2 level3Pos;

        private bool loadLevel = false;
        public StartScreen(ScreenManager screenManager, ContentManager content, GraphicsDeviceManager graphicsManager)
        {
            this.screenManager = screenManager;
            this.graphicsManager = graphicsManager;
            this.graphics = graphicsManager.GraphicsDevice;
            this.content = content;
            soundManager = new SoundManager(content);
            soundEffect = soundManager.sfx[9].CreateInstance();
            soundEffect.IsLooped = true;
            soundEffect.Play();

            backGround = content.Load<Texture2D>("Menu/lr-bg");

            resumeButton = content.Load<Texture2D>("Menu/Resume Button");
            resumeButtonPos = new Vector2((graphics.Viewport.Width / 2) - (resumeButton.Width * 0.2f) / 2, 150);

            quitButton = content.Load<Texture2D>("Menu/Quit Button");
            quitButtonPos = new Vector2((graphics.Viewport.Width / 2) - (quitButton.Width * 0.2f)/2, 400);

            level1 = content.Load<Texture2D>("Menu/Level1");
            level2 = content.Load<Texture2D>("Menu/Level2");
            level3 = content.Load<Texture2D>("Menu/Level3");
            level1Pos = new Vector2((graphics.Viewport.Width / 2) - (level1.Width) / 2, 200);
            level2Pos = new Vector2((graphics.Viewport.Width / 2) - (level2.Width) / 2, 250);
            level3Pos = new Vector2((graphics.Viewport.Width / 2) - (level3.Width) / 2, 300);
        }

        public void Update()
        {
            soundEffect.Play();
            int x = Mouse.GetState().Position.X;
            int y = Mouse.GetState().Position.Y;
            if (ScreenManager.lastState == ButtonState.Released)
            {
                if (x >= quitButtonPos.X && x <= quitButtonPos.X + quitButton.Width * 0.2f &&
                    y >= quitButtonPos.Y && y <= quitButtonPos.Y + quitButton.Height * 0.2f &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    ScreenManager.lastState = ButtonState.Pressed;
                    LunarRevenge.lunarRevenge.Exit();
                }

                if (x >= resumeButtonPos.X && x <= resumeButtonPos.X + resumeButton.Width * 0.2f &&
                    y >= resumeButtonPos.Y && y <= resumeButtonPos.Y + resumeButton.Height * 0.2f &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed && screenManager.level != null)
                {
                    ScreenManager.lastState = ButtonState.Pressed;
                    screenManager.changeState(ScreenManager.ScreenStates.level);
                }

                if (x >= level1Pos.X && x <= level1Pos.X + level1.Width &&
                    y >= level1Pos.Y && y <= level1Pos.Y + 45 &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Console.Write("level1");
                    screenManager.level = screenManager.readLevel.lvl1;
                    loadLevel = true;
                }

                if (x >= level2Pos.X && x <= level2Pos.X + level2.Width &&
                    y >= level2Pos.Y && y <= level2Pos.Y + 45 &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Console.Write("level2");
                    screenManager.level = screenManager.readLevel.lvl2;
                    loadLevel = true;
                }

                if (x >= level3Pos.X && x <= level3Pos.X + level3.Width &&
                    y >= level3Pos.Y && y <= level3Pos.Y + 45 &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Console.Write("level3");
                    screenManager.level = screenManager.readLevel.lvl3;
                    loadLevel = true;
                }

                if (loadLevel) //loads level
                {
                    soundEffect.Pause();
                    loadLevel = false;
                    screenManager.levelScreen = new LevelScreen(content, graphics, graphicsManager, screenManager);
                    screenManager.levelScreen.Init();
                    screenManager.changeState(ScreenManager.ScreenStates.level);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, new Vector2(-25,0), new Rectangle(0, 0, backGround.Width, backGround.Height), Color.White, 0f, new Vector2(0, 0), 1.35f, SpriteEffects.None, 1f);

            spriteBatch.Draw(level1, level1Pos, new Rectangle(0, 43, level1.Width, 45), Color.White);
            spriteBatch.Draw(level2, level2Pos, new Rectangle(0, 43, level1.Width, 45), Color.White);
            spriteBatch.Draw(level3, level3Pos, new Rectangle(0, 43, level1.Width, 45), Color.White);
            spriteBatch.Draw(resumeButton, resumeButtonPos, new Rectangle(0, 0, resumeButton.Width, resumeButton.Height), Color.White, 0f, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1f);
            spriteBatch.Draw(quitButton, quitButtonPos, new Rectangle(0, 0, quitButton.Width, quitButton.Height), Color.White, 0f, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1f);
        }
    }
}
