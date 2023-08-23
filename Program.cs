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
            PlayerCharacter player = new PlayerCharacter("플레이어");

            StageStart stageStart = new StageStart(player);
            stageStart.Start();


        }
    }
    
    public class Cal
    {
        public static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}
