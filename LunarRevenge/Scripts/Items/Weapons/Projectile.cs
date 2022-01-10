using LunarRevenge.Scripts.Entitys;
using LunarRevenge.Scripts.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LunarRevenge.Scripts.Items.Weapons
{
    class Projectile
    {
        private int damage;
        public Entity.Direction direction;
        private Vector2 pos;
        private int speed = 4;
        public Rectangle collisionBox;
        public Collision collision;

        public Projectile(int damage, Entity.Direction direction, Vector2 pos, Collision collision)
        {
            this.damage = damage;
            this.direction = direction;
            this.pos = pos;
            this.collision = collision;
            this.collisionBox = new Rectangle((int)pos.X, (int)pos.Y, 5,5);
        }

        public void Update()
        {
            if (direction == Entity.Direction.left) {  pos.X -= speed; }
            else if (direction == Entity.Direction.right)  {  pos.X += speed; }

            collisionBox = new Rectangle((int)(pos.X + Player.offset.X), (int)(pos.Y + Player.offset.Y), 16, 16);
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
