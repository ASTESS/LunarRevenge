using System;
using System.Collections.Generic;
using System.Text;

namespace LunarRevenge.Scripts.World.Levels
{
    internal class Level
    {
        public string MapName { get; set; }
        public LevelMapping Level1 { get; set; }
        public LevelMapping Level2 { get; set; }
        public LevelMapping Level3 { get; set; }
        public LevelMapping Level4 { get; set; }
        public LevelMapping Level5 { get; set; }
        public LevelMapping Level6 { get; set; }
        public LevelMapping Level7 { get; set; }
        public LevelMapping Level8 { get; set; }
        public LevelMapping Level9 { get; set; }
    }

    public class LevelMapping
    {
        public string[,] FloorMapping { get; set; }
        public string[,] ObstacleMapping { get; set; }
        public string[,] WallMapping { get; set; }
        public string[,] PropMapping { get; set; }
    }
}
