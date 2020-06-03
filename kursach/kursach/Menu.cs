using System;
namespace kursach
{
    class Menu
    {
        private ConsoleOutput CO;
        private ConsoleInput CI;
        private int sel;
        public Menu(){
            CO = new ConsoleOutput();
            CI = new ConsoleInput();
        }


        public void open(Game g){
            bool openFlag = true;
            while(openFlag){
                CO.menu();
                sel = CI.validMenuInput();
                switch(sel){
                    case 1:
                        g = new Game();
                        g.initial();
                        g.start();
                        break;
                    case 2:
                        FileManager FM = FileManager.GetInstance();
                        CO.PrintRecords(FM.Unpack());
                        break;
                    case 3:
                        openFlag = false;
                        break;
                }
            }
        }
    }
}
