using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LunarRevenge.Scripts.Entitys;

namespace LunarRevenge.Scripts.Content.Screens
{
    internal class GuiScreen
    {
        Texture2D healthBar;
        Entity player;
        SpriteFont font;
        public GuiScreen(ContentManager content, Entity player)
        {
            healthBar = content.Load<Texture2D>("UI/ui x1");
            font = content.Load<SpriteFont>("Font");
            this.player = player;
        }

        public void Update(GameTime gameTIme)
        {

        }

        public void Draw(GameTime gameTIme, GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            Texture2D grayBar = new Texture2D(graphics.GraphicsDevice, 80, 30);
            Color[] grayBarData = new Color[80 * 30];
            for (int i = 0; i < grayBarData.Length; ++i) grayBarData[i] = Color.Gray;
            grayBar.SetData(grayBarData);
            spriteBatch.Draw(grayBar, new Rectangle(0, graphics.GraphicsDevice.Viewport.Height - 20, graphics.GraphicsDevice.Viewport.Width, 20), Color.White);

            Texture2D blackBar = new Texture2D(graphics.GraphicsDevice, 80, 30);
            Color[] blackBarData = new Color[80 * 30];
            for (int i = 0; i < blackBarData.Length; ++i) blackBarData[i] = new Color(18,17,15);
            blackBar.SetData(blackBarData);
            spriteBatch.Draw(blackBar, new Rectangle(0, graphics.GraphicsDevice.Viewport.Height - 20, graphics.GraphicsDevice.Viewport.Width, 20), Color.White);


            drawHealth(spriteBatch, graphics);
            drawAmo(spriteBatch, graphics);
            drawScore(spriteBatch, graphics);
        }

        public void drawAmo(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            int x = 64;
            int y = 76;
            int bulletsFired = 26 - player.bullets;

            if (player.bullets >= 19)
            {
                x = 448 - 64 * bulletsFired;
                y = 140;   
            }
            else if (player.bullets <= 8)
            {
                x = 576 - (64 * (bulletsFired - 17));
                y = 76;
                if (x <= 64)
                {
                    x = 64;
                }
            }
            else if(player.bullets < 19)
            {
                x = 576 - (64 * (bulletsFired - 8));
                y = 108;
            }

            spriteBatch.Draw(healthBar, new Vector2(40, graphics.GraphicsDevice.Viewport.Height - 13), new Rectangle(x, y, 64, 7), Color.White);
        }

        private int xHealth;
        public void drawHealth(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            if (player.health >= 90)
            {
                xHealth = 323;
            }
            else if (player. health >= 80)
            {
                xHealth = 291;
            }
            else if (player.health >= 70)
            {
                xHealth = 259;
            }
            else if (player.health >= 60)
            {
                xHealth = 227;
            }
            else if (player.health >= 50)
            {
                xHealth = 195;
            }
            else if (player.health >= 40)
            {
                xHealth = 163;
            }
            else if (player.health >= 30)
            {
                xHealth = 131;
            }
            else if (player.health >= 20)
            {
                xHealth = 99;
            }
            else if (player.health >= 10)
            {
                xHealth = 67;
            }
            else if(player.health <= 0)
            {
                xHealth = 35;
            }

            spriteBatch.Draw(healthBar, new Vector2(10, graphics.GraphicsDevice.Viewport.Height - 13), new Rectangle(xHealth, 12, 26, 7), Color.White);
        }

        public void drawScore(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.DrawString(font, "score: " + Player.score.ToString(), new Vector2(graphics.GraphicsDevice.Viewport.Width - 100, graphics.GraphicsDevice.Viewport.Height - 15), Color.White);
        }
    }
}
