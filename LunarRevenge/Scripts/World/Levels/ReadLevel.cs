﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LunarRevenge.Scripts.World.Levels
{
    class ReadLevel
    {
        public Level lvl1;
        public Level lvl2;
        public Level lvl3;

        public ReadLevel()
        {
            lvl1 = new Level($@"Content\Level1.json");
            lvl2 = new Level($@"Content\Level2.json");
            lvl3 = new Level($@"Content\Level3.json");
        }
    }
}
