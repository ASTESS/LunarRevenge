using LunarRevenge.Scripts.Entitys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Items.Weapons
{
    class Projectile
    {
        private int damage;
        public Player.Direction direction;
        private Vector2 pos;
        private int speed = 4;
        public Rectangle collisionBox;
        public Projectile(int damage, Player.Direction direction, Vector2 pos)
        {
            this.damage = damage;
            this.direction = direction;
            this.pos = pos;
            this.collisionBox = new Rectangle((int)pos.X, (int)pos.Y, 5,5);
        }

        public void Update()
        {
            if (direction == Player.Direction.left)
            {
                pos.X -= speed;
            }else if(direction == Player.Direction.right)
            {
                pos.X += speed;
            }
            collisionBox = new Rectangle((int)pos.X, (int)pos.Y, 5, 5);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, GameTime gameTime)
        {
            Texture2D rect2 = new Texture2D(graphics, 80, 30);
            Color[] data2 = new Color[80 * 30];
            for (int i = 0; i < data2.Length; ++i) data2[i] = Color.Red;
            rect2.SetData(data2);
            spriteBatch.Draw(rect2, new Vector2(pos.X + Player.offset.X , pos.Y + Player.offset.Y) ,new Rectangle(10, 10, 5,5), Color.White);
        }
    }
}
