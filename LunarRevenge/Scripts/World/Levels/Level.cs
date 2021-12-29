using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.World.Levels
{
    internal class Level
    {
        public string[,] FloorMap;
        public string[,] PropMap;
        public string[,] ObstacleMap;
        public string[,] WallMap;

        public Level(string[,] floorMap, string[,] propMap, string[,] obstacleMap, string[,] wallMap)
        {
            this.FloorMap = floorMap;
            this.PropMap = propMap;
            this.ObstacleMap = obstacleMap;
            this.WallMap = wallMap;
        }
    }
}
