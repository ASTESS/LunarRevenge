using System;

namespace LunarRevenge
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new LunarRevenge())
                game.Run();
        }
    }
}
