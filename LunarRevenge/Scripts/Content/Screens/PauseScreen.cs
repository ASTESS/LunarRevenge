using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace LunarRevenge.Scripts.Content
{
    internal class PauseScreen
    {
        Rectangle startButton = new Rectangle(100, 100, 50, 50);
        ScreenManager screenManager;

        ContentManager content;
        GraphicsDevice graphics;

        private Texture2D resumeButton;
        private Vector2 resumeButtonPos;

        private Texture2D menuButton;
        private Vector2 menuButtonPos;

        public PauseScreen(ScreenManager screenManager, ContentManager content, GraphicsDevice graphics)
        {
            this.screenManager = screenManager;

            resumeButton = content.Load<Texture2D>("Menu/Resume Button");
            resumeButtonPos = new Vector2((graphics.Viewport.Width / 2) - (resumeButton.Width * 0.2f) / 2, 50);

            menuButton = content.Load<Texture2D>("Menu/Menu Button");
            menuButtonPos = new Vector2((graphics.Viewport.Width / 2) - (menuButton.Width * 0.2f) / 2, 100);
        }

        public void Update()
        {
            int x = Mouse.GetState().Position.X;
            int y = Mouse.GetState().Position.Y;

            if (ScreenManager.lastState == ButtonState.Released) {
                if (x >= resumeButtonPos.X && x <= resumeButtonPos.X + resumeButton.Width * 0.2f &&
                    y >= resumeButtonPos.Y && y <= resumeButtonPos.Y + resumeButton.Height * 0.2f &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    ScreenManager.lastState = ButtonState.Pressed;
                    screenManager.changeState(ScreenManager.ScreenStates.level);
                }
                if (x >= menuButtonPos.X && x <= menuButtonPos.X + menuButton.Width * 0.2f &&
                    y >= menuButtonPos.Y && y <= menuButtonPos.Y + menuButton.Height * 0.2f &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    ScreenManager.lastState = ButtonState.Pressed;
                    screenManager.changeState(ScreenManager.ScreenStates.home);
                }
            }
        }

        public void Draw(GraphicsDevice graphics, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(resumeButton, resumeButtonPos, new Rectangle(0, 0, resumeButton.Width, resumeButton.Height), Color.White, 0f, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1f);
            spriteBatch.Draw(menuButton, menuButtonPos, new Rectangle(0, 0, menuButton.Width, menuButton.Height), Color.White, 0f, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1f);
        }
    }
}
