using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LunarRevenge.Scripts.World.Levels
{
    class ReadLevel
    {
        private string miniLevels;
        private string bigLevels;

        string[,] floorMap = new string[11, 11] {
        {"","","","","","","","","","" ,"" },
        {"","","","floor","floor","floor","floor","floor","floor","" ,"" },
        {"","","","floorVentGreen","floor","floor","floor","floor","floor","floor" ,"" },
        {"","","","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floorQuadTile","floorCenter","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","" ,"" },
        {"","","","","","","","","","" ,"" }
        };

        string[,] floorMap2 = new string[11, 11] {
        {"","","","","","","","","","" ,"" },
        {"","","","floor","floor","floor","floor","floor","floor","" ,"" },
        {"","","","floorVentGreen","floor","floor","floor","floor","floor","floor" ,"" },
        {"","","","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floorVentGreen","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floorVentGreen","floorVentGreen","floor","floor","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floorQuadTile","floorCenter","floor" ,"" },
        {"","floor","floor","floor","floor","floor","floor","floor","floor","" ,"" },
        {"","","","","","","","","","" ,"" }
        };

        private static string[,] props = new string[11, 11] {
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","ComputerON","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","greenStain","","waterStain","","","", },
            {"","","","","","greenStain_2","","waterStain_2","","","", },
            {"","","chest_locked","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", }
        };

        private static string[,] obstacles = new string[11, 11] {
            {"","","","","","","","","","","", },
            {"","waterTopLeft","waterBottomLeft","","","","","","","","", },
            {"","waterTopMiddle","waterBottomMiddle","","","","","","","","", },
            {"","waterTopRight","waterBottomRight","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", },
            {"","","","","","","","","","","", }
        };

        private static string[,] walls = new string[11, 11] {
            {"","","","","","","","","","","", },
            {"wallTopLeft","wallLeftSide","wallLeftSide","wallLeftSideEndBottom","","wallLeftSideEndTop","wallLeftSide","wallLeftSide","wallLeftSide","wallBottomLeft","", },
            {"wallTopMiddle","","","","","","","","","wallBottomMiddle","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","","", },
            {"wallTopMiddle","","","","","","","","","wallBottomMiddle","", },
            {"wallTopRight","wallRightSide","wallRightSide","wallRightSide","wallRightSide","wallRightSide","wallCornerRightTopEnding","wallRightSide","wallRightSide","wallBottomRight","", },
            {"","","","","","","","","","","", },
        };

        string[,] brandNewFloors = JsonConvert.DeserializeObject<Level>(File.ReadAllText($@"Content\exampledata.json")).Levels[0].FloorMapping;

        
        
        public LevelMap[,] firstMap = new LevelMap[2, 2];

        Level lvl1 = new Level($@"Content\exampledata.json");

        public ReadLevel()
        {
            firstMap[0, 0] = new LevelMap(brandNewFloors, props, obstacles, walls);    // -
            firstMap[1, 0] = new LevelMap(floorMap2, props, obstacles, walls);   //  -
            firstMap[0, 1] = new LevelMap(floorMap2, props, obstacles, walls);   // _
            firstMap[1, 1] = new LevelMap(floorMap, props, obstacles, walls);    //  _
        }
    }
}
