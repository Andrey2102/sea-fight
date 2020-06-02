using System;

namespace kursach
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ConsoleOutput CO = new ConsoleOutput();
            Area PlayerArea = new Area();
            PlayerArea.ranking();
            CO.PrintUserArea2(PlayerArea);
        }
    }
}