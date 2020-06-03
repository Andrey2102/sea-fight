using System;
namespace kursach
{
    class ConsoleInput
    {
        ConsoleOutput CO = new ConsoleOutput();

        public string input(){
            return (Console.ReadLine());
        }

        public int validMenuInput()
        {
            CO.MenuSel();
            string tmp = input();
            int res;
            bool isInt = Int32.TryParse(tmp, out res);
            if (isInt && res > 0 && res < 4)
            {
                return res;
            }
            else
            {
                CO.Clear();
                CO.NoNum();
                return validMenuInput();
            }
        }

    }
}
