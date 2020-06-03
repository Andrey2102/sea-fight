using System;
namespace kursach
{
    class Player
    {
        ConsoleOutput CO = new ConsoleOutput();
        ConsoleInput CI = new ConsoleInput();
        public int points;
        public int steps;
        public Player(){
            points = 0;
            steps = 0;
        }

        public bool Win(){
            if(points == 20){
                return true;
            }
            else{
                return false;
            }
        }

        private int coord(int param){
            if (param == 0)
            {
                CO.hor();
            }
            else
            {
                CO.ver();
            }
            string tmp = CI.input();
            int res;
            bool isInt = Int32.TryParse(tmp, out res);
            if(isInt && res >= 0 && res < 10){
                return res;    
            }
            else
            {
                CO.NoNum();
                return coord(param);
            }
        }

        public Dot strike(){
            return new Dot(coord(0), coord(1));
        }
    }
}
