using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.World.Levels
{
    internal class LevelMap
    {
        public string[,] FloorMap;
        public string[,] PropMap;
        public string[,] ObstacleMap;
        public string[,] WallMap;

        public LevelMap(string[,] floorMap, string[,] propMap, string[,] obstacleMap, string[,] wallMap)
        {
            this.FloorMap = floorMap;
            this.PropMap = propMap;
            this.ObstacleMap = obstacleMap;
            this.WallMap = wallMap;
        }
    }
}
