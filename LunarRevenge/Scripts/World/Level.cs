using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.World
{
    class Level
    {
        public string[,] FloorMap { get; }
        public string[,] PropMap { get; }
        public string [,] ObstacleMap { get; }
        public string[,] WallMap { get; }

        public Level(string JSON)
        {

        }
    }
}
