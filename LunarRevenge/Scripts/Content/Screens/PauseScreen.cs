using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LunarRevenge.Scripts.Content
{
    internal class PauseScreen
    {
        Rectangle startButton = new Rectangle(100, 100, 50, 50);
        ScreenManager screenManager;

        public PauseScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        public void Draw(GraphicsDevice graphics, SpriteBatch spriteBatch)
        {
            Texture2D rect2 = new Texture2D(graphics, 80, 30);
            Color[] data2 = new Color[80 * 30];
            for (int i = 0; i < data2.Length; ++i) data2[i] = Color.White;
            rect2.SetData(data2);
            spriteBatch.Draw(rect2, startButton, Color.White);
        }
    }
}
