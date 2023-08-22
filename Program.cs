using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    internal class Program
    {
        public static void Main()
        {
            TextRPGGame game = new TextRPGGame();

            game.GameStart();
        }

    }

    public class TextRPGGame
    {
        public void GameStart()
        {
            string input;

            ICharacter player = new PlayerCharacter("플레이어");
            ICharacter merchant = new Merchant("상인");

            //IUserInterface mainInterface = new MainInterface();
            //mainInterface.Draw();


            StageShop shop = new StageShop(player, merchant);
            shop.Start();
        }

    }


}
