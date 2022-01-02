using LunarRevenge.Scripts.Entitys;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.World
{
    internal class Collision
    {
        public WorldLoader world;
        public Collision(WorldLoader world)
        {
            this.world = world;
        }
        public bool collisionCheck(Player.Direction direction, Rectangle collisionBox)
        {
            foreach (Rectangle rec in world.rectangles)
            {
                if (rec.Right >= collisionBox.Right &&
                    rec.Left + 6 <= collisionBox.Right &&
                    rec.Bottom + 16 >= collisionBox.Bottom &&
                    rec.Top - 16 <= collisionBox.Top &&
                    direction == Player.Direction.right)
                {
                    return false;
                }
                if (rec.Left <= collisionBox.Left &&
                    rec.Right >= collisionBox.Left &&
                    rec.Bottom + 16 >= collisionBox.Bottom &&
                    rec.Top - 16 <= collisionBox.Top &&
                    direction == Player.Direction.left)
                {
                    return false;
                }
                if (rec.Bottom >= collisionBox.Top &&
                    rec.Top <= collisionBox.Top
                    && rec.Right + 16 >= collisionBox.Right &&
                    rec.Left - 10 <= collisionBox.Left &&
                    direction == Player.Direction.up)
                {
                    return false;
                }
                if (rec.Top <= collisionBox.Bottom &&
                    rec.Bottom >= collisionBox.Bottom
                    && rec.Right + 16 >= collisionBox.Right &&
                    rec.Left - 10 <= collisionBox.Left &&
                    direction == Player.Direction.down)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
