using System;
using System.Collections.Generic;
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


        public Level[,] levels = new Level[2, 2];

        public ReadLevel()
        {
            levels[0, 0] = new Level(floorMap, props, obstacles, walls);
            levels[1, 0] = new Level(floorMap2, props, obstacles, walls);
            levels[0, 1] = new Level(floorMap2, props, obstacles, walls);
            levels[1, 1] = new Level(floorMap, props, obstacles, walls);
        }
    }
}
