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

        private void initial(){
            BotArea.ranking();
            PlayerArea.ranking();
            reranking();
        }

        private void start(){
            bool UWinFlag = false;
            bool UserStep = true;
            while(true){
                CO.Clear();
                CO.PrintUserArea(PlayerArea);
                CO.PrintBotArea(BotArea);    
                if(UserStep){
                    if(!BotArea.Hit(Gamer.strike())){
                        UserStep = false;
                    }
                    else{
                        Gamer.points++;
                        if (Gamer.Win())
                        {
                            UWinFlag = true;
                            break;
                        }
                    }
                }
                else{
                    if (!PlayerArea.Hit(Comp.strike()))
                    {
                        UserStep = true;
                    }
                    else
                    {
                        Comp.points++;
                        if (Comp.Win())
                        {
                            break;
                        }
                    }
                }
            }
            if(UWinFlag == true){
                CO.Win();
            }
            else{
                CO.lose();
            }
        }

        public Game()
        {
            initial();
            start();
        }
    }
}
