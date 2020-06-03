using System;
namespace kursach
{
    class Bot
    {
        public int points;
        public Bot()
        {
            points = 0;
        }
        public bool Win()
        {
            if (points == 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Dot strike(){
            Random r = new Random();
            return new Dot(r.Next(10), r.Next(10));
        }
    }
}
