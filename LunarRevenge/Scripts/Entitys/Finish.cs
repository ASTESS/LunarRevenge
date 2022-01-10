﻿using LunarRevenge.Scripts.Content.Screens;
using LunarRevenge.Scripts.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LunarRevenge.Scripts.Entitys
{
    internal class Finish : Entity
    {
        private Vector2 postition;
        public Finish(Texture2D texture, Collision collision, string name, Vector2 pos) : base(texture, collision, name)
        {
            this.postition = pos;
        }

        public override void Update(GameTime gameTime)
        {
            pos = new Vector2((postition.X - 16) + Player.offset.X, (postition.Y - 16) + Player.offset.Y);
            collisionBox = new Rectangle((int)pos.X, (int)pos.Y, 32,32);
            collision.collisionCheck((Player)LevelScreen.entitys["player"]);
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, GameTime gameTime)
        {
            spriteBatch.Draw(texture, pos, new Rectangle(0, 0, 32, 32), Color.White, 0f, new Vector2(width / 2, height / 2), 1f, flip, 1f);
        }
    }
}