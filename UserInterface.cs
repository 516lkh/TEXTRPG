using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{

    public interface IUserInterface
    {
        char sym { get; }
        int horizontal { get; set; }
        int vertical { get; set; }

        public void Draw();
        public void Clear();
    }


    public class MainInterface : IUserInterface
    {
        public char sym { get; }
        public int horizontal { get; set; }
        public int vertical { get; set; }

        public MainInterface()
        {
            horizontal = 80;
            vertical = 25;
            sym = '#';
        }

        public void Draw()
        {
            for(int i = 0; i <=horizontal; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(sym);
                Console.SetCursorPosition(i, vertical);
                Console.Write(sym);
            }

            for (int j = 0; j <= vertical; j++)
            {
                Console.SetCursorPosition(0, j);
                Console.Write(sym);
                Console.SetCursorPosition(horizontal, j);
                Console.Write(sym);
            }
        }

        public void Clear()
        {

        }
    }
}
