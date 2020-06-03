using System;
namespace kursach
{
    class Area
    {
        private ConsoleOutput CO = new ConsoleOutput();

        public int [,] GArea = new int [10,10];

        public bool Hit(Dot d){
            if(GArea[d.x, d.y] == 0){
                GArea[d.x, d.y] = 3;
                return false;
            }
            if (GArea[d.x, d.y] == 1)
            {
                GArea[d.x, d.y] = 2;
                if(sunken(d)){
                    Around(new Dot(-5, -5), d);
                }
                return true;
            }
            else{
                CO.attacked();
                return true;
            }
        }


        private bool inRange(Dot d){
            if (d.x >= 0 && d.x < 10 && d.y >= 0 && d.y < 10)
            {
                return true;
            }
            return false;
        }

        private void Around(Dot from, Dot d){
            if(inRange(new Dot(d.x + 1, d.y + 1))){
                if (GArea[d.x + 1, d.y + 1] == 0)
                {

                    GArea[d.x + 1, d.y + 1] = 3;
                }
            }
            if (inRange(new Dot(d.x + 1, d.y - 1)))
            {
                if (GArea[d.x + 1, d.y - 1] == 0)
                {

                    GArea[d.x + 1, d.y - 1] = 3;
                }
            }
            if (inRange(new Dot(d.x - 1, d.y + 1)))
            {
                if (GArea[d.x - 1, d.y + 1] == 0)
                {

                    GArea[d.x - 1, d.y + 1] = 3;
                }
            }
            if (inRange(new Dot(d.x - 1, d.y - 1)))
            {
                if (GArea[d.x - 1, d.y - 1] == 0)
                {

                    GArea[d.x - 1, d.y - 1] = 3;
                }
            }
            if (inRange(new Dot(d.x + 1, d.y)))
            {
                if (GArea[d.x + 1, d.y] == 0)
                {
                    GArea[d.x + 1, d.y] = 3;
                }
                if(GArea[d.x + 1, d.y] == 2 && d.x + 1 != from.x && d.y != from.y){
                    Around(d, new Dot(d.x + 1, d.y));
                }
            }

            if (inRange(new Dot(d.x - 1, d.y)))
            {
                if (GArea[d.x - 1, d.y] == 0)
                {
                    GArea[d.x - 1, d.y] = 3;
                }
                if (GArea[d.x - 1, d.y] == 2 && d.x - 1 != from.x && d.y != from.y)
                {
                    Around(d, new Dot(d.x - 1, d.y));
                }
            }

            if (inRange(new Dot(d.x, d.y + 1)))
            {
                if (GArea[d.x, d.y + 1] == 0)
                {
                    GArea[d.x, d.y + 1] = 3;
                }
                if (GArea[d.x, d.y + 1] == 2 && d.x != from.x && d.y + 1 != from.y)
                {
                    Around(d, new Dot(d.x, d.y + 1));
                }
            }
            if (inRange(new Dot(d.x, d.y - 1)))
            {
                if (GArea[d.x, d.y - 1] == 0)
                {
                    GArea[d.x, d.y - 1] = 3;
                }
                if (GArea[d.x, d.y - 1] == 2 && d.x != from.x && d.y - 1 != from.y)
                {
                    Around(d, new Dot(d.x, d.y - 1));
                }
            }
        }


        private bool sunken(Dot d){
            if(sunkAval(d, new Dot(d.x + 1, d.y))
               && sunkAval(d, new Dot(d.x - 1, d.y))
               && sunkAval(d, new Dot(d.x, d.y + 1))
               && sunkAval(d, new Dot(d.x, d.y - 1))){
                return true;
            }
            return false;
        }


        private bool sunkAval(Dot from, Dot d)
        {
            if (d.x == 10 || d.x == -1 || d.y == 10 || d.y == -1)
            {
                return true;
            }
            else
            {
                if (GArea[d.x, d.y] == 0 || GArea[d.x, d.y] == 3)
                {
                    return true;
                }
                else
                {
                    if (GArea[d.x, d.y] == 1)
                    {
                        return false;
                    }
                    else
                    {
                        if (GArea[d.x, d.y] == 2)
                        {
                            if (d.x + 1 == from.x)
                            {
                                return (sunkAval(d, new Dot(d.x - 1, d.y))
                                        && sunkAval(d, new Dot(d.x, d.y + 1))
                                        && sunkAval(d, new Dot(d.x, d.y - 1)));
                            }
                            if(d.x - 1 == from.x){
                                return (sunkAval(d, new Dot(d.x + 1, d.y))
                                        && sunkAval(d, new Dot(d.x, d.y + 1))
                                        && sunkAval(d, new Dot(d.x, d.y - 1)));
                            }
                            if(d.y - 1 == from.y){
                                return (sunkAval(d, new Dot(d.x - 1, d.y))
                                        && sunkAval(d, new Dot(d.x, d.y + 1))
                                        && sunkAval(d, new Dot(d.x + 1, d.y)));
                            }
                            else{
                                return (sunkAval(d, new Dot(d.x - 1, d.y))
                                        && sunkAval(d, new Dot(d.x + 1, d.y))
                                        && sunkAval(d, new Dot(d.x, d.y - 1)));
                            }

                        }
                        return true;
                    }
                }
            }
        }

        public void ranking(){
            ranking4();
            ranking3();
            ranking3();
            ranking2();
            ranking2();
            ranking2();
            ranking1();
            ranking1();
            ranking1();
            ranking1();

        }
        private void ranking1()
        {
            var random = new Random();
            var x = random.Next(10);
            var y = random.Next(10);
            if (isAvalLocation(x, y)){
                GArea[x, y] = 1;
            }
            else{
                ranking1();
            }
        }

        private void ranking2()
        {
            var random = new Random();
            var x = random.Next(10);
            var y = random.Next(10);
            int k = random.Next(10) % 2;
            if(k == 0){
                if (isAvalLocation(x, y) && isAvalLocation(x, y+1))
                {
                    GArea[x, y] = 1;
                    GArea[x, y+1] = 1;
                }
                else
                {
                    ranking2();
                }
            }
            else{
                if (isAvalLocation(x, y) && isAvalLocation(x + 1, y))
                {
                    GArea[x, y] = 1;
                    GArea[x + 1, y] = 1;
                }
                else
                {
                    ranking2();
                }
            }
        }

        private void ranking3()
        {
            var random = new Random();
            var x = random.Next(10);
            var y = random.Next(10);
            int k = random.Next(10) % 2;
            if (k == 0)
            {
                if (isAvalLocation(x, y) && isAvalLocation(x, y + 1) && isAvalLocation(x, y + 2))
                {
                    GArea[x, y] = 1;
                    GArea[x, y + 1] = 1;
                    GArea[x, y + 2] = 1;
                }
                else
                {
                    ranking3();
                }
            }
            else
            {
                if (isAvalLocation(x, y) && isAvalLocation(x + 1, y) && isAvalLocation(x + 2, y))
                {
                    GArea[x, y] = 1;
                    GArea[x + 1, y] = 1;
                    GArea[x + 2, y] = 1;
                }
                else
                {
                    ranking3();
                }
            }
        }

        private void ranking4()
        {
            var random = new Random();
            var x = random.Next(10);
            var y = random.Next(10);
            int k = random.Next(10) % 2;
            if (k == 0)
            {
                if (isAvalLocation(x, y) && isAvalLocation(x, y + 1) && isAvalLocation(x, y + 2) && isAvalLocation(x, y + 3))
                {
                    GArea[x, y] = 1;
                    GArea[x, y + 1] = 1;
                    GArea[x, y + 2] = 1;
                    GArea[x, y + 3] = 1;
                }
                else
                {
                    ranking4();
                }
            }
            else
            {
                if (isAvalLocation(x, y) && isAvalLocation(x + 1, y) && isAvalLocation(x + 2, y) && isAvalLocation(x + 3, y))
                {
                    GArea[x, y] = 1;
                    GArea[x + 1, y] = 1;
                    GArea[x + 2, y] = 1;
                    GArea[x + 3, y] = 1;
                }
                else
                {
                    ranking4();
                }
            }
        }

        private bool isAval(int x, int y)
        {
            if(x >= 0 && x < 10 && y >= 0 && y < 10 && GArea[x, y] == 0){
                return true;
            }
            else{
                if(x == 10 || x == -1 || y == 10 || y == -1){
                    return true;
                }
            }
            return false;
        }

        private bool isAval(int x, int y, int param)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10 && GArea[x, y] == 0)
            {
                return true;
            }
            return false;
        }

        public bool isAvalLocation(int x, int y)
        {
            if (isAval(x - 1, y - 1)
               && isAval(x - 1, y)
               && isAval(x - 1, y + 1)
               && isAval(x, y - 1)
               && isAval(x, y, 1)
               && isAval(x, y + 1)
               && isAval(x + 1, y - 1)
               && isAval(x + 1, y)
               && isAval(x + 1, y + 1))
            {
                return true;
            }
            else {
                return false; 
            }
        }
    }
}
