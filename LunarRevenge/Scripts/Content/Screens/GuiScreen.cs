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


            drawHealth(spriteBatch, graphics);
            drawAmo(spriteBatch, graphics);
        }

        public void drawAmo(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            int x = 64;
            int y = 76;
            int bulletsFired = 26 - player.bullets;
            Console.WriteLine(bulletsFired);
            if (player.bullets >= 19)
            {
                x = 448 - 64 * bulletsFired;
                y = 140;
                //8
                
            }else if (player.bullets <= 8)
            {
                x = 576 - (64 * (bulletsFired - 17));
                y = 76;
                if (x <= 64)
                {
                    x = 64;
                }
                //9
            }else if(player.bullets < 19)
            {
                x = 576 - (64 * (bulletsFired - 8));
                y = 108;
                //10
            }

            spriteBatch.Draw(healthBar, new Vector2(40, graphics.GraphicsDevice.Viewport.Height - 13), new Rectangle(x, y, 64, 7), Color.White);
        }

        public void drawHealth(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
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
