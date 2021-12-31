using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Content.Screens
{
    internal class GuiScreen
    {

        public void Update(GameTime gameTIme)
        {

        }

        public void Draw(GameTime gameTIme, GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            Rectangle rectangle = new Rectangle(0, graphics.GraphicsDevice.Viewport.Height - 20, graphics.GraphicsDevice.Viewport.Width, 20);


            Texture2D rect2 = new Texture2D(graphics.GraphicsDevice, 80, 30);
            Color[] data2 = new Color[80 * 30];
            for (int i = 0; i < data2.Length; ++i) data2[i] = Color.Gray;
            rect2.SetData(data2);
            spriteBatch.Draw(rect2, rectangle, Color.White);
        }
    }
}
