using System;
namespace kursach
{
    class Game
    {
        private ConsoleOutput CO = new ConsoleOutput();
        private ConsoleInput CI = new ConsoleInput();

        private Area BotArea = new Area();
        private Bot Comp = new Bot();


        private Area PlayerArea = new Area();
        private Player Gamer = new Player();

        private void reranking(){

            CO.PrintUserArea(PlayerArea);
            CO.PrintBotArea(BotArea);
            CO.reranking();
            string tmp = CI.input();
            if(tmp == "yes"){
                PlayerArea = new Area();
                PlayerArea.ranking();
                CO.Clear();
                reranking();
            }
            else{
                if(tmp == "no"){
                    return;
                }
                else{
                    CO.Clear();
                    CO.err();
                    reranking();
                }
            }
        }

        public void initial(){
            BotArea.ranking();
            PlayerArea.ranking();
            reranking();
        }

        public void start(){
            bool UWinFlag = false;
            bool UserStep = true;
            int tmp;
            while(true){
                CO.Clear();
                CO.PrintUserArea(PlayerArea);
                CO.PrintBotArea(BotArea);    

                if(UserStep){
                    tmp = BotArea.Hit(Gamer.strike());
                    switch(tmp){
                        case 0:
                            UserStep = false;
                            Gamer.steps++;
                            break;
                        case 1:
                            Gamer.points++;
                            break;
                        default:
                            CO.attacked();
                            break;
                    }
                        if (Gamer.Win())
                        {
                            UWinFlag = true;
                            break;
                        }
                    }
                else{
                    tmp = PlayerArea.Hit(Comp.strike());
                    switch (tmp)
                    {
                        case 0:
                            UserStep = true;
                            break;
                        case 1:
                            Comp.points++;
                            break;
                        default:
                            break;
                    }
                    if (Comp.Win())
                    {
                        break;
                    }
                }
            }

            if(UWinFlag == true){
                CO.Win();
                FileManager fm = FileManager.GetInstance();
                Record r = new Record(Gamer.points, UWinFlag);
                fm.Pack(r);
            }
            else{
                CO.lose();
                FileManager fm = FileManager.GetInstance();
                Record r = new Record(Gamer.points, UWinFlag);
                fm.Pack(r);
            }
        }
    }
}
