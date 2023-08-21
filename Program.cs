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

        }

    }

    public class TRGame
    {
        public static void GameStart()
        {
            while (true) 
            {
                

            }
        }

    }

    public interface IUserInterface
    {
        char sym { get; }
        int horizontal { get; set; }
        int vertical { get; set; }

        public void Draw();
        public void Clear();
    }

    public class MainInterface:IUserInterface
    {
        public char sym { get; }
        public int horizontal { get; set; }
        public int vertical { get; set; }

        MainInterface()
        {

        }

        public void Draw()
        {

        }

        public void Clear()
        {

        }
    }

}
