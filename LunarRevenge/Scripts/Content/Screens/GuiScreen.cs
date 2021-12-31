using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using LunarRevenge.Scripts.Entitys;

namespace LunarRevenge.Scripts.Content.Screens
{
    internal class GuiScreen
    {
        Texture2D healthBar;
        Entity player;
        public GuiScreen(ContentManager content, Entity player)
        {
            healthBar = content.Load<Texture2D>("UI/ui x1");
            this.player = player;
        }

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

            if (player.health == 100)
            {
                spriteBatch.Draw(healthBar, new Vector2(10, graphics.GraphicsDevice.Viewport.Height - 13), new Rectangle(323, 12, 26, 7), Color.White);
            }
            else
            {
                spriteBatch.Draw(healthBar, new Vector2(10, graphics.GraphicsDevice.Viewport.Height - 13), new Rectangle(35, 12, 26, 7), Color.White);
            }
            
        }
    }
}
