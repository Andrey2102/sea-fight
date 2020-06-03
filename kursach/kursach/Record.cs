using System;
namespace kursach
{
    public class Record
    {
        public string Name;
        public int steps;
        public bool Win;

        public Record(){}
        public Record(int steps, bool win){
            ConsoleOutput CO = new ConsoleOutput();
            ConsoleInput CI = new ConsoleInput();
            CO.Name();
            Name = CI.input();
            this.steps = steps;
            this.Win = win;
        }
    }
}
