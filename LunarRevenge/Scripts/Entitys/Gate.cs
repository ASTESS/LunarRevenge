using LunarRevenge.Scripts.Content.Screens;
using LunarRevenge.Scripts.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.Entitys
{
    internal class Gate : Entity
    {
        private Vector2 postition = new Vector2(0, 0);
        public Gate(Texture2D texture, Vector2 pos, Collision collision, string name) : base(texture, collision, name)
        {
            this.health = 50;
            speed = 1f;
            this.postition = pos;
        }

        public override void Update(GameTime gameTime)
        {
            pos = new Vector2(postition.X + Player.offset.X, postition.Y + Player.offset.Y);
            base.Update(gameTime);
        }

        public override void Animation(GameTime gameTime)
        {
            if (state == EntityState.idle)
            {
                startingX = 0;
                startingY = 672;
                width = 32;
                height = 32;
                frames = 1;
                currentX = startingX;
                duration = 150;
            }

            timeFromPreFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeFromPreFrame > duration)
            {
                timeFromPreFrame -= duration;
                if (frames > 1)
                {
                    currentX += width;
                    if (32 * (frames - 1) < currentX)
                    {
                        currentX = startingX;

                        if (state == EntityState.death)
                        {
                            LevelScreen.entitys.Remove(name);
                        }
                    }
                }
            }
        }
    }
}
