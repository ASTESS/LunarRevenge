using Newtonsoft.Json;
using System.IO;

namespace LunarRevenge.Scripts.World.Levels
{
    internal class Level
    {
        public string MapName { get; set; }
        public int LevelSize { get; set; }
        public LevelMapping[] Levels { get; set; }

        public Level(string JSON)
        {
            if (JSON != null)
            {
                Level l = JsonConvert.DeserializeObject<Level>(File.ReadAllText(JSON));
                this.MapName = l.MapName;
                this.LevelSize = l.LevelSize;
                this.Levels = l.Levels;
            }
        }
    }

    public class LevelMapping
    {
        public string[,] FloorMapping { get; set; }
        public string[,] ObstacleMapping { get; set; }
        public string[,] WallMapping { get; set; }
        public string[,] PropMapping { get; set; }
    }
}
