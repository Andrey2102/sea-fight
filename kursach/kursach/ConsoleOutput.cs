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

        private void UAreaChar(int n)
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

        private void BAreaChar(int n)
        {
            switch (n)
            {
                case 0:
                    Console.Write('\u25A0' + " ");
                    break;
                case 1:
                    Console.Write('\u25A0' + " ");
                    break;
                case 2:
                    Console.Write('\u25b3' + " ");
                    break;
                case 3:
                    Console.Write('\u229b' + " ");
                    break;
            }
        }

        public void reranking(){
            Console.Write("Do you want to rerank area?(yes/no): ");
        }

        public void PrintUserArea(Area tmp)
        {
            Console.WriteLine("PLAYER AREA\n");
            Console.WriteLine("   0 1 2 3 4 5 6 7 8 9");

            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " |");

                for (int j = 0; j < 10; j++)
                {
                    UAreaChar(tmp.GArea[i, j]);
                }
                Console.Write('\n');
            }
        }

        public void PrintBotArea(Area tmp)
        {
            Console.WriteLine("BOT AREA\n");
            Console.WriteLine("   0 1 2 3 4 5 6 7 8 9");

            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " |");

                for (int j = 0; j < 10; j++)
                {
                    BAreaChar(tmp.GArea[i, j]);
                }
                Console.Write('\n');
            }
        }

        public void err(){
            Console.WriteLine("Oops, your input isn`t valid. Try again.");
        }

        public void Clear(){
            Console.Clear();
        }

        public void attacked()
        {
            Console.WriteLine("This place was attacked. Try again.");
        }

        public void NoNum()
        {
            Console.WriteLine("Bad input. Try again.");
        }

        public void lose()
        {
            Clear();
            Console.WriteLine("You lose!");
        }

        public void Win()
        {
            Clear();
            Console.WriteLine("You win.");
        }
    }
}
