using System;
namespace kursach
{
    class ConsoleOutput
    {
        public void hor(){
            Console.WriteLine("Enter horizontal coordinate: ");
        }

        public void ver()
        {
            Console.WriteLine("Enter vertical coordinate: ");
        }

        private void AreaChar(int n)
        {
            switch (n)
            {
                case 0:
                    Console.Write('\u25A0' + " ");
                    break;
                case 1:
                    Console.Write('\u25A1' + " ");
                    break;
                case 2:
                    Console.Write('\u25b3' + " ");
                    break;
                case 3:
                    Console.Write('\u229b' + " ");
                    break;
            }
        }



        public void PrintUserArea(Area tmp)
        {
            for (int i = 0; i < 10; i++){

                for (int j = 0; j < 10; j++){
                    Console.Write(tmp.GArea[i, j] + " ");
                }
                Console.Write('\n');
            }
        }

        public void PrintUserArea2(Area tmp)
        {
            Console.WriteLine("   0 1 2 3 4 5 6 7 8 9");

            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " |");

                for (int j = 0; j < 10; j++)
                {
                    AreaChar(tmp.GArea[i, j]);
                }
                Console.Write('\n');
            }
        }
    }
}
