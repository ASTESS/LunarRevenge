using LunarRevenge.Scripts.Content.Screens;
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
        public List<Rectangle> collisions;

        public Collision(WorldLoader world)
        {
            this.world = world;
            collisions = new List<Rectangle>();
        }
        public bool collisionCheck(Entity.Direction direction, Rectangle collisionBox)
        {
            world.rectangles.AddRange(collisions);
            collisions.Clear();
            foreach (Rectangle rec in world.rectangles)
            {
                if (rec.Right >= collisionBox.Right &&
                    rec.Left + 6 <= collisionBox.Right &&
                    rec.Bottom + 16 >= collisionBox.Bottom &&
                    rec.Top - 16 <= collisionBox.Top &&
                    direction == Entity.Direction.right)
                {
                    return false;
                }
                if (rec.Left <= collisionBox.Left &&
                    rec.Right >= collisionBox.Left &&
                    rec.Bottom + 16 >= collisionBox.Bottom &&
                    rec.Top - 16 <= collisionBox.Top &&
                    direction == Entity.Direction.left)
                {
                    return false;
                }
                if (rec.Bottom >= collisionBox.Top &&
                    rec.Top <= collisionBox.Top
                    && rec.Right + 16 >= collisionBox.Right &&
                    rec.Left - 10 <= collisionBox.Left &&
                    direction == Entity.Direction.up)
                {
                    return false;
                }
                if (rec.Top <= collisionBox.Bottom &&
                    rec.Bottom >= collisionBox.Bottom
                    && rec.Right + 16 >= collisionBox.Right &&
                    rec.Left - 10 <= collisionBox.Left &&
                    direction == Entity.Direction.down)
                {
                    return false;
                }
            }
            return true;
        }

        public bool collisionCheck(Rectangle collisionBox)
        {
            foreach (KeyValuePair<string, Entity> entity in LevelScreen.entitys)
            {
                if (collisionBox.Intersects(entity.Value.collisionBox) && !(entity.Value.GetType() == typeof(Player)))
                {
                    entity.Value.damageEntity(60f);
                    return false;
                }
            }
            return true;
        }
    }
}
