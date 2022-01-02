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
        public Level lvl1;

        public ReadLevel()
        {
            lvl1 = new Level($@"Content\exampledata.json");
        }
    }
}
