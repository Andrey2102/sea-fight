using System;

namespace kursach
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Game g = new Game();
            Menu m = new Menu();
            m.open(g);
        }
    }
}