using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LunarRevenge.Scripts.World.Textures
{
    class WorldTexture
    {
        public Texture2D texture;
        public Rectangle collisionBox;

        public WorldTexture(Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            this.collisionBox = rectangle;
        }
    }
}
